using Metcom.CardPay3.ApplicationCore.Entities.PersonAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.Infrastructure.Config
{
    public class RequisitesConfiguration : IEntityTypeConfiguration<PersonRequisites>
    {
        public void Configure(EntityTypeBuilder<PersonRequisites> builder)
        {
            builder.ToTable("Requisites");
        }
    }
}
