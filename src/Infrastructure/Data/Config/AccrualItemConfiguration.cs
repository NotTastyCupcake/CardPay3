using Metcom.CardPay3.ApplicationCore.Entities.AccrualAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.Infrastructure.Data.Config
{
    public class AccrualItemConfiguration : IEntityTypeConfiguration<AccrualItem>
    {
        public void Configure(EntityTypeBuilder<AccrualItem> builder)
        {
            builder.Property(bi => bi.Amount)
                .IsRequired(true)
                .HasColumnType("decimal(18,2)");

            builder.Property(bi => bi.Date)
                .IsRequired(true);
        }
    }
}
