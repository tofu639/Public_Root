using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicsReporting.Shared.Extensions
{

    public static class SharedServiceRegistrationExtension
    {
        public static IServiceCollection AddSharedServices(this IServiceCollection services)
        {
            // Add shared services here, for example:
            // services.AddSingleton<IMyService, MyService>();

            return services; // Ensure the method always returns the IServiceCollection instance.
        }
    }

}
