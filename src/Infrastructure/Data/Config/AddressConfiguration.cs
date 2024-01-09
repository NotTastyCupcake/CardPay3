using Metcom.CardPay3.ApplicationCore.Entities.AccrualAggregate;
using Metcom.CardPay3.ApplicationCore.Entities.AddressAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.Infrastructure.Data.Config
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(e => e.Id);

            builder.OwnsOne(a => a.Country, cg => { cg.ToTable("CountryGeographic"); });

            builder.OwnsOne(a => a.State, cg => { cg.ToTable("StateGeographic"); });

            builder.OwnsOne(a => a.City, cg => { cg.ToTable("CityGeographic"); });

            builder.OwnsOne(a => a.Locality, cg => { cg.ToTable("LocalityGeographic"); });

            builder.OwnsOne(a => a.Street, cg => { cg.ToTable("StreetGeographic"); });

        }
    }
}
