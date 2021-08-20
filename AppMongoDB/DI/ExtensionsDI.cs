using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using Microsoft.Extensions.DependencyInjection;

namespace AppMongoDB.DI
{
    public static class ExtensionsDi
    {
        public static IServiceProvider AddTransientServiceCollection<TService, TImplementation>(this IServiceCollection services) where TImplementation : class, TService where TService : class
        {
            services.AddTransient<TService, TImplementation>();

            return services.BuildServiceProvider();
        }
    }
}