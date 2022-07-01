using Metcom.CardPay3.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.Infrastructure.Config
{
    public class GenderConfiguration : IEntityTypeConfiguration<PersonGender>
    {
        public void Configure(EntityTypeBuilder<PersonGender> builder)
        {
            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.GenderName)
                .IsRequired(true);

            builder.Property(ci => ci.ShortGenderName)
                .IsRequired(true);
        }
    }
}
