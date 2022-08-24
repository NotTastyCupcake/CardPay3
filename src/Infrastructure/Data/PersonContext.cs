using Metcom.CardPay3.ApplicationCore.Entities;
using Metcom.CardPay3.ApplicationCore.Entities.AddressAggregate;
using Metcom.CardPay3.ApplicationCore.Entities.DocumentAggregate;
using Metcom.CardPay3.ApplicationCore.Entities.GroupAggregate;
using Metcom.CardPay3.ApplicationCore.Entities.RequisitesAggtegate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.Infrastructure.Data
{
    public class PersonContext : DbContext
    {
        DbSet<Group> Groups { get; set; }
        DbSet<PersonItem> People { get; set; }
        DbSet<PersonGender> Genders { get; set; }
        DbSet<DocumentItem> Documents { get; set; }
        DbSet<RequisitesItem> Requisites { get; set; }

        DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        
    }
    
}
