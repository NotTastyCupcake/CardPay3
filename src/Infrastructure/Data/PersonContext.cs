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
    public class PersonContext : DbContext
    {
        public PersonContext(DbContextOptions<PersonContext> options) 
            : base(options)
        {
        }

        public PersonContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<PersonItem> People { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<PersonOrganization> Organizations { get; set; }
        public DbSet<PersonGender> Genders { get; set; }
        public DbSet<DocumentItem> Documents { get; set; }
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
