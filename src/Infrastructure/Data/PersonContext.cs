using Metcom.CardPay3.ApplicationCore.Entities.AddressAggregate;
using Metcom.CardPay3.ApplicationCore.Entities.PersonAggregate;
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
        DbSet<PersonGroup> Groups { get; set; }
        DbSet<PersonItem> People { get; set; }
        DbSet<PersonGender> Genders { get; set; }
        DbSet<PersonDocument> Documents { get; set; }
        DbSet<PersonRequisites> Requisites { get; set; }

        DbSet<Address> Addresses { get; set; }
        DbSet<ActualAddressItem> ActualAddresses { get; set; }
        DbSet<MailAddressItem> MailAddresses { get; set; }
        DbSet<ResidenceAddressItem> ResidenceAddresses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        
    }
    
}
