using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metcom.CardPay3.ApplicationCore.Entities.AccrualAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Metcom.CardPay3.Infrastructure.Data.Config
{
    public class AccrualConfiguration : IEntityTypeConfiguration<Accrual>
    {
        public void Configure(EntityTypeBuilder<Accrual> builder)
        {
            builder.HasKey(ci => ci.Id);
            builder.ToTable("Accrual");

            var navigation = builder.Metadata.FindNavigation(nameof(Accrual.Items));
            navigation?.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.HasOne(ci => ci.Organization)
                .WithMany()
                .HasForeignKey(ci => ci.IdOrganization);

            builder.HasOne(ci => ci.OperationType)
                .WithMany()
                .HasForeignKey(ci => ci.IdOperationType);

            builder.Property(b => b.AccrualDay)
                .IsRequired(true)
                .HasMaxLength(3);
        }
    }
}
