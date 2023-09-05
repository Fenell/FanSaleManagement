using AutoMapper;
using FSM_Application.Catalog.ProductCatalog;
using FSM_Application.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FSM_Application
{
    public static class ApplicationRegister
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddScoped(typeof(IAllRepositorys<>), typeof(AllRepositorys<>));

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
