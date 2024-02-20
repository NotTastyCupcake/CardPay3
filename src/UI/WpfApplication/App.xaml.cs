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
using Metcom.CardPay3.WpfApplication.Interfaces;
using Metcom.CardPay3.WpfApplication.Services;
using Metcom.CardPay3.WpfApplication.ViewModels;
using Metcom.CardPay3.WpfApplication.ViewModels.Employes;
using Metcom.CardPay3.WpfApplication.ViewModels.Employes.DocumentCRUD;
using Metcom.CardPay3.WpfApplication.ViewModels.Employes.RequisitiesCRUD;
using Metcom.CardPay3.WpfApplication.ViewModels.Organizations;
using Metcom.CardPay3.WpfApplication.Views;
using Metcom.CardPay3.WpfApplication.Views.Employes;
using Metcom.CardPay3.WpfApplication.Views.Employes.Requisities;
using Metcom.CardPay3.WpfApplication.Views.Organization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ReactiveUI;
using Splat;
using Splat.Microsoft.Extensions.DependencyInjection;
using Splat.Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Windows;

namespace Metcom.CardPay3.WpfApplication;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App// : Application
{

    public IConfiguration Configuration { get; private set; }

    public IServiceProvider Container { get; private set; }
    private IHost _host;
    public App()
    {
        Initialize();
        /* Some other initialization stuff */
    }

    private async void Initialize()
    {
        var builder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        Configuration = builder.Build();

        _host = Host
            .CreateDefaultBuilder()
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

    protected override async void OnStartup(StartupEventArgs e)
    {
        await _host.StartAsync();

        var mainWindow = _host.Services.GetRequiredService<IViewFor<ShallViewModel>>();
        if (mainWindow is ShellWindow window)
        {
            window.Show();
        }

        base.OnStartup(e);
    }

    private void ConfigureDevelopmentServices(IServiceCollection services)
    {
        // use in-memory database
        //ConfigureInMemoryDatabases(services);

        // use real ms database
        ConfigureMsSqlDatabases(services);

        ConfigureServices(services);
    }

    private void ConfigureMsSqlDatabases(IServiceCollection services)
    {
        Infrastructure.Dependencies.ConfigureServices(Configuration, services);
    }

    private void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>));
        services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

        services.AddScoped<IAccrualService, AccrualService>();

        services.AddScoped<IHomeViewModelService, HomeViewModelService>();
        services.AddScoped<IEmployeeViewModelService, EmployeeViewModelService>();
        services.AddScoped<IDocumentViewModelService, DocumentViewModelService>();
        services.AddScoped<IEmployeeCollectionService, EmployeeCollectionService>();
        services.AddScoped<ISettingService, SettingService>();
        services.AddScoped<IOneCMappingService, OneCMappingService>();
        services.AddScoped<IOneCSerializeService, OneCSerializeService>();
        services.AddScoped<IOneCService,  OneCService>();

        services.AddTransient<IEmployeeBuilder, EmployeeBuilder>();
        services.AddTransient<IEmployeeBuilderSendObj, EmployeeBuilder>();
        services.AddTransient<IEmployeeBuilderSendField, EmployeeBuilder>();

        services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
        services.AddTransient<IEmailSender, EmailSender>();
        services.AddTransient<IDataExportService, DataExportService>();

        // register your personal services here, for example
        services.AddSingleton<ShallViewModel>(); //Implements IScreen
        services.AddSingleton<IScreen, ShallViewModel>(x => x.GetRequiredService<ShallViewModel>());
        services.AddSingleton<IViewFor<ShallViewModel>, ShellWindow>();

        //alternatively search assembly for `IRoutedViewFor` implementations
        //see https://reactiveui.net/docs/handbook/routing to learn more about routing in RxUI
        services.AddSingleton<IViewFor<MenuViewModel>, MenuView>();
        services.AddSingleton<MenuViewModel>();

        services.AddSingleton<IViewFor<SettingsViewModel>, SettingsView>();
        services.AddSingleton<SettingsViewModel>();

        services.AddTransient<IViewFor<CreateOrganizationViewModel>, CreateOrganizationView>();
        services.AddTransient<CreateOrganizationViewModel>();
        services.AddTransient<IViewFor<EditOrganizationViewModel>, EditOrganizationView>();
        services.AddTransient<EditOrganizationViewModel>();

        services.AddScoped<IViewFor<EmployeeListViewModel>, EmployeeListView>();
        services.AddScoped<EmployeeListViewModel>();
        services.AddTransient<IViewFor<CreateEmployeeViewModel>, CreateEmployeeView>();
        services.AddTransient<CreateEmployeeViewModel>();
        services.AddTransient<IViewFor<EditEmployeeViewModel>, EditEmployeeView>();
        services.AddTransient<EditEmployeeViewModel>();

        services.AddTransient<IViewFor<CreateDocumentViewModel>, CreateDocumentView>();
        services.AddTransient<CreateDocumentViewModel>();

        services.AddTransient<IViewFor<CreateRequisitiesViewModel>, CreateRequisitiesView>();
        services.AddTransient<CreateRequisitiesViewModel>();
    }

}