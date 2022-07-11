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
    public class GroupConfiguration : IEntityTypeConfiguration<PersonGroup>
    {
        public void Configure(EntityTypeBuilder<PersonGroup> builder)
        {
            builder.ToTable("Group");

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Name)
                .IsRequired(true);
        }
    }
}
