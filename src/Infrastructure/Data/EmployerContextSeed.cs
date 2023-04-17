using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.Infrastructure.Data
{
    public class EmployerContextSeed
    {
        public static Task SeedAsync(EmployerContext catalogContext, ILoggerFactory loggerFactory)
        {
            // TODO: Добавить примеры клиентов
            return Task.CompletedTask;
        }
    }
}
