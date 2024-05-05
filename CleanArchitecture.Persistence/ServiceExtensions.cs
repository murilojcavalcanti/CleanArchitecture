using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Persistence.Context;
using CleanArchitecture.Persistence.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CleanArchitecture.Persistence
{
     public static class ServiceExtensions
    {
        //Metodo para persistencia de dados
        //Aqui estão as configurações de serviços e comportamentos relacionados à aplicação.
        public static void ConfigurePersistanceApp(this IServiceCollection services,  IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("sqlite");
           
            services.AddDbContext<AppDbContext>(opt=>opt.UseSqlite(connectionString));
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            
            services.AddScoped<IUserRepository, UserRepository>();
        }

    }
}
