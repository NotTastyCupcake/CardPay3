﻿using Metcom.CardPay3.ApplicationCore.Entities.RequisitesAggtegate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Metcom.CardPay3.Infrastructure.Data.Config
{
    public class RequisitesConfiguration : IEntityTypeConfiguration<RequisitesItem>
    {
        public void Configure(EntityTypeBuilder<RequisitesItem> builder)
        {
            builder.HasKey(ci => ci.Id);

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
