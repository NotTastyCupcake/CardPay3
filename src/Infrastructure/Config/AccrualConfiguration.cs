using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metcom.CardPay3.ApplicationCore.Entities.AccrualAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Metcom.CardPay3.Infrastructure.Config
{
    public class AccrualConfiguration : IEntityTypeConfiguration<Accrual>
    {
        public void Configure(EntityTypeBuilder<Accrual> builder)
        {
            var navigation = builder.Metadata.FindNavigation(nameof(Accrual.Items));
            navigation?.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.Property(b => b.Id)
                .IsRequired()
                .HasMaxLength(256);
        }
    }
}
