using Metcom.CardPay3.ApplicationCore.Entities;
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
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Id)
                .UseHiLo("employer_group_hilo")
                .IsRequired();

            var navigation = builder.Metadata.FindNavigation(nameof(Group.Items));
            navigation?.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.Property(ci => ci.Name)
                .IsRequired();

            builder.HasOne(ci => ci.Organization)
                .WithMany()
                .HasForeignKey(ci => ci.IdOrganization);
        }
    }
}
