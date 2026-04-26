using DemoWeb.Codes;
using DemoWeb.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

//builder.Services.AddScoped<IMembership, ImprovedMembership>(); // one instance per per http life cyle or request
//builder.Services.AddSingleton<IMembership, ImprovedMembership>(); // one instance for the entire application
//builder.Services.AddTransient<IMembership, ImprovedMembership>(); // a new instance every time it's requested

//builder.Services.AddKeyedScoped<IMembership, Membership>("Setup 1"); // Keyed used for using multiple implementations of the same interface, and you can specify which implementation to use based on a key. In this case, "Setup 1" is the key for the Membership implementation.
//builder.Services.AddKeyedScoped<IMembership, ImprovedMembership>("Setup 2");
//builder.Services.AddScoped<IMembership, ImprovedMembership>(s=> new ImprovedMembership("Trial")); // This line registers the ImprovedMembership class as the implementation of the IMembership interface with a scoped lifetime. The lambda expression is used to create an instance of ImprovedMembership, passing "Trial" as a parameter to its constructor. This allows you to customize the instantiation of the ImprovedMembership class when it is requested from the dependency injection container.
builder.Services.AddTransient<INotificationService, EmailService>();
//builder.Services.AddTransient<INotificationService, SmsService>();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
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

app.Run();
