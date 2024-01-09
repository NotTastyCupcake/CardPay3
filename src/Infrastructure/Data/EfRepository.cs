using Ardalis.Specification.EntityFrameworkCore;
using Metcom.CardPay3.ApplicationCore.Interfaces;

namespace Metcom.CardPay3.Infrastructure.Data
{
    public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class
    {
        public EfRepository(EmployeContext dbContext) : base(dbContext)
        {
        }
    }
}
