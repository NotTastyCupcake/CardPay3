using Metcom.CardPay3.ApplicationCore.Interfaces.ServicesInterfaces.Builder;
using Metcom.CardPay3.ApplicationCore.Interfaces.ServicesInterfaces;
using Metcom.CardPay3.ApplicationCore.Interfaces;
using Metcom.CardPay3.ApplicationCore.Services.Builder;
using Metcom.CardPay3.ApplicationCore.Services;
using Metcom.CardPay3.Infrastructure.Data;
using Metcom.CardPay3.Infrastructure.Identity;
using Metcom.CardPay3.WpfApplication.ViewModels;
using Microsoft.AspNetCore.Identity;
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
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Metcom.CardPay3.Infrastructure.Logging;
using Metcom.CardPay3.Infrastructure.Services;
using Metcom.CardPay3.ApplicationCore.Entities;
using Metcom.CardPay3.ApplicationCore.Entities.AccrualAggregate;
using Metcom.CardPay3.WpfApplication.Interfaces;
using Metcom.CardPay3.WpfApplication.Services;
using Metcom.CardPay3.WpfApplication.Views;
using Metcom.CardPay3.WpfApplication.ViewModels.Employes;
using Metcom.CardPay3.WpfApplication.Views.Employes;
using System.Windows.Forms;

namespace Metcom.CardPay3.WpfApplication;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App// : Application
{

    public IConfiguration Configuration { get; private set;}

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

        var mainWindow = _host.Services.GetRequiredService<IViewFor<HomeViewModel>>();
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
        //services.AddDbContext<AppIdentityDbContext>(options =>
        //    options.UseSqlServer(
        //        Configuration.GetConnectionString("IdentityConnection")));

        services.AddDbContext<EmployeContext>(options =>
            options.UseSqlServer(
                Configuration.GetConnectionString("MainConnection")));
    }

    private void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>));
        services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

        services.AddScoped<IAccrualService, AccrualService>();
        services.AddScoped<IEmployeService, EmployeService>();

        services.AddScoped<IHomeViewModelService, HomeViewModelService>();
        services.AddScoped<IEmployeViewModelService, EmployeViewModelService>();
        services.AddScoped<IEmployeCollectionService, EmployeCollectionService>();

        services.AddScoped<IEmployeBuilder, EmployeBuilder>();

        services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
        services.AddTransient<IEmailSender, EmailSender>();
        services.AddTransient<IDataExportService, DataExportService>();

        // register your personal services here, for example
        services.AddSingleton<HomeViewModel>(); //Implements IScreen
        services.AddSingleton<IScreen, HomeViewModel>(x => x.GetRequiredService<HomeViewModel>());
        services.AddSingleton<IViewFor<HomeViewModel>, ShellWindow>();

        //alternatively search assembly for `IRoutedViewFor` implementations
        //see https://reactiveui.net/docs/handbook/routing to learn more about routing in RxUI
        services.AddSingleton<IViewFor<MenuViewModel>, MenuView>();
        services.AddSingleton<MenuViewModel>();

        services.AddTransient<IViewFor<EmployeeListViewModel>, EmployeListView>();
        services.AddTransient<EmployeeListViewModel>();

        services.AddScoped<IViewFor<EmployeViewModel>, EmployeView>();
        services.AddScoped<EmployeViewModel>();

        services.AddScoped<IViewFor<AddressViewModel>, AddAddressView>();
        services.AddScoped<AddressViewModel>();

    }

}