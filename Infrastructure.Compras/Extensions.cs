using Application.Compras;
using Domain.Compras.Repositories;
using Infrastructure.Compras.EF;
using Infrastructure.Compras.EF.Context;
using Infrastructure.Compras.EF.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Compras
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddApplication();
            services.AddDbContext<ReadDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ComprasConnectionString"));
            });
            services.AddDbContext<WriteDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ComprasConnectionString"));
            });

            //Scoped: se crea una instancia por cada request
            //Transient: se crea una instancia por cada uso
            //Singleton: se crea una instancia por cada aplicación
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICompraRepository, CompraRepository>();
            services.AddScoped<IProveedorRepository, ProveedorRepository>();
            services.AddScoped<IProductoRepository, ProductoRepository>();


            return services;
        }
        
        public static bool Contains(this string source, string toCheck, StringComparison comp)
        {
            return source?.IndexOf(toCheck, comp) >= 0;
        }

    }
}
