using Metcom.CardPay3.ApplicationCore.Entities.RequisitesAggtegate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.Infrastructure.Data.Config
{
    public class RequisitesConfiguration : IEntityTypeConfiguration<RequisitesItem>
    {
        public void Configure(EntityTypeBuilder<RequisitesItem> builder)
        {

            builder.HasOne(ci => ci.Division)
                .WithOne()
                .HasForeignKey<RequisitesItem>(ci => ci.IdDivision)
                .IsRequired(true);

            builder.HasOne(ci => ci.Currency)
                .WithOne()
                .HasForeignKey<RequisitesItem>(ci => ci.IdCurrency)
                .IsRequired(true);

            builder.HasOne(ci => ci.CardType)
                .WithOne()
                .HasForeignKey<RequisitesItem>(ci => ci.IdCardType)
                .IsRequired(true);
        }
    }
}
