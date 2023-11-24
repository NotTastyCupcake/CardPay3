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
            builder.HasOne(ci => ci.Country)
                .WithMany()
                .HasForeignKey(ci => ci.IdCountry)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(true);

            builder.HasOne(ci => ci.State)
                .WithMany()
                .HasForeignKey(ci => ci.IdState)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(true);

            builder.HasOne(ci => ci.City)
                .WithMany()
                .HasForeignKey(ci => ci.IdCity)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(true);

            builder.HasOne(ci => ci.Locality)
                .WithMany()
                .HasForeignKey(ci => ci.IdLocality)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(true);

            builder.HasOne(ci => ci.Street)
                .WithMany()
                .HasForeignKey(ci => ci.IdStreet)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(true);
        }
    }
}
