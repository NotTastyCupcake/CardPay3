using Metcom.CardPay3.ApplicationCore.Entities.GroupAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.Infrastructure.Data.Config
{
    public class GroupItemConfiguration : IEntityTypeConfiguration<GroupItem>
    {
        public void Configure(EntityTypeBuilder<GroupItem> builder)
        {
            builder.HasKey(ci => ci.Id);

            builder.Property(bi => bi.EmployerId)
                .IsRequired();
        }
    }
}
