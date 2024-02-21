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
            if (Database.CanConnect())
            {
                Database.EnsureCreated();
            }
            
        }

        public EmployeContext()
        {

        }

        public DbSet<Employee> Employers { get; set; }
        public DbSet<EmployeeType> TypeEmployers { get; set; }

        public DbSet<Group> Groups { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Gender> Genders { get; set; }

        public DbSet<DocumentItem> Documents { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }

        public DbSet<BankDivision> Banks { get; set; }
        public DbSet<BankCurrency> Currencies { get; set; }
        public DbSet<BankCardType> CardTypes { get; set; }
        public DbSet<RequisitesItem> Requisites { get; set; }
        public DbSet<Status> Statuses { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Accrual> Accruals { get; set; }
        public DbSet<AccrualItem> AccrualItems { get; set; }
        public DbSet<OperationType> Operations { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        //TODO: Inegration test https://www.thinktecture.com/en/entity-framework-core/entity-framework-core7-n1-queries-problem/
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies();
        }
    }

}
