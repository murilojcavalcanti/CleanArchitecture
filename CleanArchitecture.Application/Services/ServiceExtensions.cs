using CleanArchitecture.Domain.Interfaces;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Services
{
    public static class ServiceExtensions
    {
        //Registra os serviços do AutoMapper,Mediatr e FluentValidation no contêiner DI
        //Assembly.GetExecutingAssembly()->Especifica que o serviço deve ser configurado para atuar dentro
        //do Assembly onde o método está definido(Application)
        public static void ConfigureApplicationApp(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            
            services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
