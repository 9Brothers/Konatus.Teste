using System;
using Konatus.Teste.Application;
using Konatus.Teste.Application.Interfaces;
using Konatus.Teste.Domain.Interfaces.Repositories.Excel;
using Konatus.Teste.Domain.Interfaces.Repositories.SqlServer;
using Konatus.Teste.Domain.Interfaces.Services;
using Konatus.Teste.Domain.Services;
using Konatus.Teste.Infrastructure.Excel;
using Konatus.Teste.Infrastructure.SqlServer;
using Microsoft.Extensions.DependencyInjection;

namespace Konatus.Teste.Infrastructure.IoC
{
    public abstract class Injector
    {
        public static void Inject(IServiceCollection services)
        {
            // * AppService Repositories
            services.AddScoped<IAeronaveAppService, AeronaveAppService>();
            services.AddScoped<IModeloAeronaveAppService, ModeloAeronaveAppService>();

            // * Service Repositories
            services.AddScoped<IModeloAeronaveService, ModeloAeronaveService>();
            services.AddScoped<IAeronaveService, AeronaveService>();

            // * Sql Server Repositories            
            services.AddScoped<IModeloAeronaveSqlServerRepository, ModeloAeronaveSqlServerRepository>();
            services.AddScoped<IAeronaveSqlServerRepository, AeronaveSqlServerRepository>();

            // * Excel Repositories
            services.AddScoped(typeof(IExcelRepository<>), typeof(ExcelRepository<>));
        }
    }
}