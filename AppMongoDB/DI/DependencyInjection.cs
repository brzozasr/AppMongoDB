using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using Microsoft.Extensions.DependencyInjection;

namespace AppMongoDB.DI
{
    public class DependencyInjection : IDependencyResolver
    {
        private IServiceScope _serviceScope;
        protected IServiceProvider ServiceProvider { get; set; }

        public DependencyInjection(IServiceProvider serviceProvider)
        {
            this.ServiceProvider = serviceProvider;
        }

        public object GetService(Type serviceType)
        {
            return this.ServiceProvider.GetService(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this.ServiceProvider.GetServices(serviceType);
        }

        public IDependencyScope BeginScope()
        {
            _serviceScope = this.ServiceProvider.CreateScope();
            return new DependencyInjection(_serviceScope.ServiceProvider);
        }

        public void Dispose()
        {
            _serviceScope?.Dispose();
        }
    }
}