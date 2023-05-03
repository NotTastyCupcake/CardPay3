using Metcom.CardPay3.ApplicationCore.Entities;
using Metcom.CardPay3.ApplicationCore.Entities.AccrualAggregate;
using Metcom.CardPay3.ApplicationCore.Entities.AddressAggregate;
using Metcom.CardPay3.ApplicationCore.Entities.DocumentAggregate;
using Metcom.CardPay3.ApplicationCore.Entities.GroupAggregate;
using Metcom.CardPay3.ApplicationCore.Entities.RequisitesAggtegate;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Metcom.CardPay3.Infrastructure.Data
{
    public class EmployeContext : DbContext
    {
        public EmployeContext(DbContextOptions<EmployeContext> options) 
            : base(options)
        {
        }

        public EmployeContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<Employe> Employers { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Gender> Genders { get; set; }

        public DbSet<DocumentItem> Documents { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }

        public DbSet<BankDivision> Banks { get; set; }
        public DbSet<BankCurrency> Currencies { get; set; }
        public DbSet<BankCardType> CardTypes { get; set; }
        public DbSet<RequisitesItem> Requisites { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Accrual> Accruals { get; set; }
        public DbSet<AccrualItem> AccrualItems { get; set; }
        public DbSet<OperationType> Operations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        
    }
    
}
