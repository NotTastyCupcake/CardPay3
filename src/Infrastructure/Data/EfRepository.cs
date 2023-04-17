using Ardalis.Specification.EntityFrameworkCore;
using Metcom.CardPay3.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.Infrastructure.Data
{
    public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class
    {
        public EfRepository(EmployerContext dbContext) : base(dbContext)
        {
        }
    }
}
