using Metcom.CardPay3.ApplicationCore.Entities;
using Metcom.CardPay3.ApplicationCore.Entities.RequisitesAggtegate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Metcom.CardPay3.Infrastructure.Data.Config
{
    public class EmployeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.Document)
                .WithOne()
                .HasForeignKey<Employee>(e => e.IdDocument)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.Addresses)
                .WithOne(a => a.Employee)
                .HasForeignKey(a => a.IdEmployee)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Gender)
                .WithMany()
                .HasForeignKey(e => e.IdGender)
                .IsRequired(true);

            builder.HasOne(e => e.Requisite)
                .WithOne(r => r.Employee)
                .HasForeignKey<Employee>(e => e.IdRequisite)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Organization)
                .WithMany()
                .HasForeignKey(e => e.IdOrganization)
                .IsRequired(true);

            builder.HasOne(e => e.Type)
                .WithOne(o => o.Employee)
                .HasForeignKey<Employee>(e => e.IdType)
                .IsRequired(false);

            builder.Property(e => e.LastName)
                .IsRequired(true)
                .HasMaxLength(50);

            builder.Property(e => e.FirstName)
                .IsRequired(true)
                .HasMaxLength(50);

            builder.Property(e => e.MiddleName)
                .IsRequired(false)
                .HasMaxLength(50);
        }
    }
}
