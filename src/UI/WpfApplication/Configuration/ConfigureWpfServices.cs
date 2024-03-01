using Metcom.CardPay3.WpfApplication.Interfaces;
using Metcom.CardPay3.WpfApplication.Models;
using Metcom.CardPay3.WpfApplication.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Metcom.CardPay3.WpfApplication.Configuration
{
    public static class ConfigureWpfServices
    {
        public static IServiceCollection AddWpfServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IHomeViewModelService, HomeViewModelService>();
            services.AddScoped<IEmployeeViewModelService, EmployeeViewModelService>();
            services.AddScoped<IDocumentViewModelService, DocumentViewModelService>();
            services.AddScoped<IEmployeeCollectionService, EmployeeCollectionService>();
            services.AddScoped<ISettingService, SettingService>();

            return services;
        }
    }
}
