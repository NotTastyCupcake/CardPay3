using Metcom.CardPay3.ApplicationCore.Interfaces.OneC;
using Metcom.CardPay3.ApplicationCore.Interfaces;
using Metcom.CardPay3.ApplicationCore.Services;
using Metcom.CardPay3.Infrastructure.Data;
using Metcom.CardPay3.Infrastructure.Services;
using Metcom.CardPay3.Integration.Interfaces;
using Metcom.CardPay3.Integration.Services;
using Metcom.CardPay3.WpfApplication.Interfaces;
using Metcom.CardPay3.WpfApplication.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metcom.CardPay3.ApplicationCore.Interfaces.ServicesInterfaces.Builder;
using Metcom.CardPay3.ApplicationCore.Services.Builder;
using Metcom.CardPay3.Infrastructure.Logging;

namespace Metcom.CardPay3.WpfApplication.Configuration
{
    public static class ConfigureCoreServices
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

            services.AddScoped<IAccrualService, AccrualService>();

            services.AddScoped<IOneCMappingService, OneCMappingService>();
            services.AddScoped<IOneCSerializeService, OneCSerializeService>();
            services.AddScoped<IOneCService, OneCService>();

            services.AddTransient<IEmployeeBuilder, EmployeeBuilder>();

            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<IDataExportService, DataExportService>();

            return services;
        }
    }
}
