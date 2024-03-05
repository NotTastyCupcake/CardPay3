using Metcom.CardPay3.ApplicationCore.Interfaces;
using Metcom.CardPay3.ApplicationCore.Interfaces.OneC;
using Metcom.CardPay3.ApplicationCore.Interfaces.ServicesInterfaces;
using Metcom.CardPay3.ApplicationCore.Interfaces.ServicesInterfaces.Builder;
using Metcom.CardPay3.ApplicationCore.Services;
using Metcom.CardPay3.ApplicationCore.Services.Builder;
using Metcom.CardPay3.Infrastructure.Data;
using Metcom.CardPay3.Infrastructure.Logging;
using Metcom.CardPay3.Infrastructure.Services;
using Metcom.CardPay3.Integration.Interfaces;
using Metcom.CardPay3.Integration.Services;
using Metcom.CardPay3.WpfApplication.Configuration;
using Metcom.CardPay3.WpfApplication.Interfaces;
using Metcom.CardPay3.WpfApplication.Services;
using Metcom.CardPay3.WpfApplication.ViewModels;
using Metcom.CardPay3.WpfApplication.ViewModels.Employes;
using Metcom.CardPay3.WpfApplication.ViewModels.Employes.DocumentCRUD;
using Metcom.CardPay3.WpfApplication.ViewModels.Employes.RequisitiesCRUD;
using Metcom.CardPay3.WpfApplication.ViewModels.Organizations;
using Metcom.CardPay3.WpfApplication.Views;
using Metcom.CardPay3.WpfApplication.Views.Employes;
using Metcom.CardPay3.WpfApplication.Views.Employes.Documents;
using Metcom.CardPay3.WpfApplication.Views.Employes.Requisities;
using Metcom.CardPay3.WpfApplication.Views.Organization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;
using ReactiveUI;
using Splat;
using Splat.Microsoft.Extensions.DependencyInjection;
using Splat.Microsoft.Extensions.Logging;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows;

namespace Metcom.CardPay3.WpfApplication;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App// : Application
{
    public IConfiguration Configuration { get; private set; }

    public IServiceProvider Container { get; private set; }

    protected IHost _host;

    public App()
    {
        Initialize().GetAwaiter().GetResult();
        /* Some other initialization stuff */
    }

    private async Task Initialize()
    {

        var builder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json", optional: false);

        Configuration = builder.Build();

        _host = Host
            .CreateDefaultBuilder(Environment.GetCommandLineArgs())
            .ConfigureServices(services =>
            {
                services.UseMicrosoftDependencyResolver();
                var resolver = Locator.CurrentMutable;
                resolver.InitializeSplat();
                resolver.InitializeReactiveUI();

                ConfigureDevelopmentServices(services);
            })
            .ConfigureLogging(loggingBuilder =>
            {
                loggingBuilder.AddConfiguration(Configuration);
                loggingBuilder.AddEventLog();
                loggingBuilder.AddSplat();
            })
            //.UseEnvironment(Environments.Development)
            .Build();

        Container = _host.Services;
        Container.UseMicrosoftDependencyResolver();

        using (var scope = _host.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            var loggerFactory = services.GetRequiredService<ILoggerFactory>();
            try
            {
                var catalogContext = services.GetRequiredService<EmployeContext>();
                await EmployeContextSeed.SeedAsync(catalogContext, loggerFactory);
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<App>();
                logger.LogError(ex, "An error occurred seeding the DB.");
            }
        }

    }

    protected override void OnStartup(StartupEventArgs e)
    {
        _host.Start();

        var dbContext = _host.Services.GetService<EmployeContext>();

        if (dbContext != null && dbContext.Database.CanConnect())
        {
            var mainWindow = _host.Services.GetRequiredService<IViewFor<ShallViewModel>>();
            if (mainWindow is ShellWindow window)
            {
                window.Show();
            }
        }
        else
        {
            var mainWindow = _host.Services.GetRequiredService<IViewFor<SettingsViewModel>>();
            if (mainWindow is Window window)
            {
                window.Show();
            }
        }


        base.OnStartup(e);
    }

    private void ConfigureDevelopmentServices(IServiceCollection services)
    {
        // use in-memory database
        //ConfigureInMemoryDatabases(services);

        // use real ms database
        ConfigureSqlDatabases(services, Configuration);

        ConfigureServices(services, Configuration);
    }

    private void ConfigureSqlDatabases(IServiceCollection services, IConfiguration configuration)
    {
        Infrastructure.Dependencies.ConfigureServices(configuration, services);
    }

    private void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddCoreServices(configuration);
        services.AddWpfServices(configuration);

        // register your personal services here, for example
        services.AddSingleton<ShallViewModel>(); //Implements IScreen
        services.AddSingleton<IScreen, ShallViewModel>(x => x.GetRequiredService<ShallViewModel>());
        services.AddSingleton<IViewFor<ShallViewModel>, ShellWindow>();

        services.AddSingleton<SettingsViewModel>();
        services.AddSingleton<IViewFor<SettingsViewModel>, SettingsView>();

        //alternatively search assembly for `IRoutedViewFor` implementations
        //see https://reactiveui.net/docs/handbook/routing to learn more about routing in RxUI
        services.AddSingleton<MenuViewModel>();
        services.AddSingleton<IViewFor<MenuViewModel>, MenuView>();

        services.AddSingleton<SettingsViewModel>();
        services.AddSingleton<IViewFor<SettingsViewModel>, SettingsView>();

        services.AddTransient<CreateOrganizationViewModel>();
        services.AddTransient<IViewFor<CreateOrganizationViewModel>, CreateOrganizationView>();
        services.AddTransient<EditOrganizationViewModel>();
        services.AddTransient<IViewFor<EditOrganizationViewModel>, EditOrganizationView>();

        services.AddScoped<EmployeeListViewModel>();
        services.AddScoped<IViewFor<EmployeeListViewModel>, EmployeeListView>();
        services.AddTransient<CreateEmployeeViewModel>();
        services.AddTransient<IViewFor<CreateEmployeeViewModel>, CreateEmployeeView>();
        services.AddTransient<EditEmployeeViewModel>();
        services.AddTransient<IViewFor<EditEmployeeViewModel>, EditEmployeeView>();

        services.AddTransient<CreateDocumentViewModel>();
        services.AddTransient<IViewFor<CreateDocumentViewModel>, CreateDocumentView>();

        services.AddTransient<CreateRequisitiesViewModel>();
        services.AddTransient<IViewFor<CreateRequisitiesViewModel>, CreateRequisitiesView>();
    }

}