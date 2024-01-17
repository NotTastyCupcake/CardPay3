using Metcom.CardPay3.Infrastructure.Data;
using Metcom.CardPay3.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.Infrastructure
{
    public static class Dependencies
    {
        public static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {
            string dataBaseType = "MSSQL";

            if (configuration["DataBaseType"] != null)
            {
                dataBaseType = configuration["DataBaseType"];
            }

            if(dataBaseType == "MSSQL")
            {

                services.AddDbContext<EmployeContext>(c =>
                    c.UseSqlServer(configuration.GetConnectionString("MainConnection")));

                //services.AddDbContext<AppIdentityDbContext>(options =>
                //    options.UseSqlServer(configuration.GetConnectionString("IdentityConnection")));
            }
            else if (dataBaseType == "PostgresSQL")
            {
                AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

                services.AddDbContext<EmployeContext>(c =>
                    c.UseNpgsql(configuration.GetConnectionString("MainConnection")));
            }
        }
    }
}
