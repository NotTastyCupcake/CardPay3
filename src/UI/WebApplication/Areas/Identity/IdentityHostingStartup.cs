using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Metcom.CardPay3.WebApplication.Areas.Identity.IdentityHostingStartup))]
namespace Metcom.CardPay3.WebApplication.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}