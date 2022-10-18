using CGM.CashExchange.Core.Application.Behaviours;
using CGM.CashExchange.Core.Application.Contracts.Ports.Services.Reports;
using CGM.CashExchange.Core.Application.Contracts.Ports.Services.Rest;
using CGM.CashExchange.Infrastructure.Adapters.Services.Reports;
using CGM.CashExchange.Infrastructure.Adapters.Services.Rest;
using CGM.CashExchange.Infrastructure.Adapters.Services.Rest.Contracts;
using CGM.Infrastructure.Persistence.SqlServer.Contexts;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CGM.CashExchange.Infrastructure
{
    public static class InfrastructureConfigureService
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextConfig(configuration);
            services.AddRefitRest(configuration);
            services.AddAdapters();


            return services;
        }
        private static IServiceCollection AddDbContextConfig(this IServiceCollection services, IConfiguration configuration)
        {
            var secureSettings = configuration.GetSection("ConnectionStrings");
            services.AddDbContext<CashExchangeContext>(options =>
                        options.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"],
                            b => b.MigrationsAssembly(typeof(CashExchangeContext).Assembly.FullName)
                            .CommandTimeout(180)
                            .MinBatchSize(5000)
                            .MaxBatchSize(10000)
                            ));


            return services;
        }
        private static IServiceCollection AddAdapters(this IServiceCollection services)
        {
            services.AddTransient<IMaccorpService, MaccorpService>();
            services.AddTransient<IPdfService, RdlcService>();
            return services;
        }
        private static IServiceCollection AddRefitRest(this IServiceCollection services, IConfiguration configuration)
        {
            var settings = new RefitSettings
            {
                ContentSerializer = new NewtonsoftJsonContentSerializer()
            };
            services.AddRefitClient<IMaccorpRest>(settings)
                .ConfigureHttpClient(x => x.BaseAddress = new Uri(configuration["RestServices:Maccord"]))
                .ConfigureHttpClient((c) => c.DefaultRequestHeaders.Add("API-KEY", "e89dd3bd-8f69-472f-a919-8322dce9cfae"));
            return services;
        }
    
    }
}
