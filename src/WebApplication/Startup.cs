using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Metcom.CardPay3.Infrastructure.Identity;
using Metcom.CardPay3.Infrastructure.Services;
using Metcom.CardPay3.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Identity;
using Metcom.CardPay3.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using System;
using Metcom.CardPay3.Infrastructure.Logging;
using Metcom.CardPay3.WebApplication.Services;
using Metcom.CardPay3.ApplicationCore.Services;
using Metcom.CardPay3.WebApplication.Interfaces;

namespace Metcom.CardPay3.WebApplication
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureDevelopmentServices(IServiceCollection services)
        {
            // use in-memory database
            //ConfigureInMemoryDatabases(services);

            // use real ms database
            ConfigureMsSqlDatabases(services);

            ConfigureServices(services);
        }

        public void ConfigureMsSqlDatabases(IServiceCollection services)
        {
            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("IdentityConnection")));

            services.AddDbContext<EmployeContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("MainConnection")));
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureCookieSettings(services);
            CreateIdentityIfNotCreated(services);

            services.AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

            services.AddScoped<IAccrualService, AccrualService>();

            services.AddScoped<IAccrualViewModelService, AccrualViewModelService>();
            services.AddScoped<IEmployerViewModelService, EmployerViewModelService>();

            services.Configure<CardPaySettings>(Configuration);
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddHealthChecks();
        }





        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }

        private static void CreateIdentityIfNotCreated(IServiceCollection services)
        {
            var sp = services.BuildServiceProvider();
            using (var scope = sp.CreateScope())
            {
                var existingUserManager = scope.ServiceProvider
                    .GetService<UserManager<ApplicationUser>>();
                if (existingUserManager == null)
                {
                    services.AddIdentity<ApplicationUser, IdentityRole>()
                        .AddDefaultUI()
                        .AddEntityFrameworkStores<AppIdentityDbContext>()
                                        .AddDefaultTokenProviders();
                    services.AddAuthentication();
                }
            }
        }
        private static void ConfigureCookieSettings(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromHours(1);
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
                options.Cookie = new CookieBuilder
                {
                    IsEssential = true // required for auth to work without explicit user consent; adjust to suit your privacy policy
                };
            });
        }
    }
}
