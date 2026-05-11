using Autofac;
using Autofac.Extensions.DependencyInjection;
using DemoWeb;
using DemoWeb.Codes;
using DemoWeb.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using DemoInfrastructure.Extensions;
using System.Reflection;


Log.Logger = new LoggerConfiguration()
    .WriteTo.File("Logs/web-log-.log", rollingInterval: RollingInterval.Day)
    .CreateBootstrapLogger();

try {
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
    var maigrationAssembly = Assembly.GetAssembly(typeof(ApplicationDbContext));

    #region Dependency Injection

    builder.Services.AddInfrastructureDependency();

    #endregion

    #region Serilog Configuration
    builder.Host.UseSerilog((context, lc) => lc
        .MinimumLevel.Debug()
        .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning)
        .Enrich.FromLogContext()
        .ReadFrom.Configuration(context.Configuration)
        );
    #endregion

    #region Autofac Configuration
    builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
    builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
    {
        // Register your services with Autofac here
        //containerBuilder.RegisterType<Membership>().Keyed<IMembership>("Setup 1").InstancePerLifetimeScope().WithParameter("name", "Ariful");
        //containerBuilder.RegisterType<ImprovedMembership>().Keyed<IMembership>("Setup 2").SingleInstance();
        containerBuilder.RegisterModule(new WebModule(connectionString));
    });
    #endregion

    #region DbContext Configuration
    builder.Services.AddDbContext(connectionString, maigrationAssembly);
    #endregion

    builder.Services.AddDatabaseDeveloperPageExceptionFilter();

    builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
        .AddEntityFrameworkStores<ApplicationDbContext>();
    builder.Services.AddControllersWithViews();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseMigrationsEndPoint();
    }
    else
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseRouting();

    app.UseAuthorization();

    app.MapStaticAssets();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
        .WithStaticAssets();

    app.MapRazorPages()
       .WithStaticAssets();
    Log.Information("Application Starting");

    app.Run();
}
catch(Exception ex)
{
    Log.Fatal(ex, "Application Crashed");
}
finally{
    Log.CloseAndFlush();
}