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

namespace Metcom.CardPay3.WpfApplication;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App// : Application
{

    public IConfiguration Configuration { get; private set;}

    public IServiceProvider Container { get; private set; }

    public App()
    {
        Initialize();
        /* Some other initialization stuff */
    }

    private void Initialize()
    {
        var builder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        Configuration = builder.Build();

        var host = Host
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
            .UseEnvironment(Environments.Development)
            .Build();

        Container = host.Services;
        Container.UseMicrosoftDependencyResolver();

        using (var scope = host.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            var loggerFactory = services.GetRequiredService<ILoggerFactory>();
            try
            {
                var catalogContext = services.GetRequiredService<EmployeContext>();
                Task.Run(() => EmployeContextSeed.SeedAsync(catalogContext, loggerFactory));

                var MainWindow = (MainWindow)services.GetRequiredService<IViewFor<HomeViewModel>>();
                MainWindow.Show();


            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<App>();
                logger.LogError(ex, "An error occurred seeding the DB.");
            }
        }

    }

    //protected override void OnStartup(StartupEventArgs e)
    //{

    //}

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
        services.AddDbContext<AppIdentityDbContext>(options =>
            options.UseSqlServer(
                Configuration.GetConnectionString("IdentityConnection")));

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

        services.AddScoped<IEmployeBuilder, EmployeBuilder>();

        services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
        services.AddTransient<IEmailSender, EmailSender>();


        // register your personal services here, for example
        services.AddSingleton<HomeViewModel>(); //Implements IScreen

        // this passes IScreen resolution through to the previous viewmodel registration.
        // this is to prevent multiple instances by mistake.
        services.AddSingleton<IRoutableViewModel, HomeViewModel>(x => x.GetRequiredService<HomeViewModel>());

        services.AddSingleton<IViewFor<HomeViewModel>, MainWindow>();



        //alternatively search assembly for `IRoutedViewFor` implementations
        //see https://reactiveui.net/docs/handbook/routing to learn more about routing in RxUI
        //services.AddTransient<IViewFor<SecondaryViewModel>, SecondaryPage>();
        //services.AddTransient<SecondaryViewModel>();
    }

}