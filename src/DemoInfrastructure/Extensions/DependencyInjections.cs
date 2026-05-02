using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace DemoInfrastructure.Extensions
{
    public static class DependencyInjections
    {
        public static ISelectionService AddInfrastructure(this ISelectionService services)
        {
            Services.AddScoped<IMembership, ImprovedMembership>(); // one instance per per http life cyle or request
                                                                           //builder.Services.AddSingleton<IMembership, ImprovedMembership>(); // one instance for the entire application
                                                                           //builder.Services.AddTransient<IMembership, ImprovedMembership>(); // a new instance every time it's requested

            //builder.Services.AddKeyedScoped<IMembership, Membership>("Setup 1"); // Keyed used for using multiple implementations of the same interface, and you can specify which implementation to use based on a key. In this case, "Setup 1" is the key for the Membership implementation.
            //builder.Services.AddKeyedScoped<IMembership, ImprovedMembership>("Setup 2");
            //builder.Services.AddScoped<IMembership, ImprovedMembership>(s => new ImprovedMembership("Trial")); // This line registers the ImprovedMembership class as the implementation of the IMembership interface with a scoped lifetime. The lambda expression is used to create an instance of ImprovedMembership, passing "Trial" as a parameter to its constructor. This allows you to customize the instantiation of the ImprovedMembership class when it is requested from the dependency injection container.
            ////builder.Services.AddTransient<INotificationService, EmailService>();
            //builder.Services.AddTransient<INotificationService, SmsService>();
            return services;
        }
    }
}
