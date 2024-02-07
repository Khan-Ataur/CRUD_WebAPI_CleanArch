using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDWebAPICleanArch.Infrastructure
{
    public static class ServiceCollectionExtension
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            //services.AddTransient<IProductRepository, ProductRepository>();
            //services.AddTransient<IContactRepository, ContactRepository>();
            //services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
