﻿using Metcom.CardPay3.ApplicationCore.Entities.AddressAggregate;
using Metcom.CardPay3.ApplicationCore.Entities.DocumentAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.Infrastructure.Data.Config
{
    public class DocumentConfiguration : IEntityTypeConfiguration<DocumentItem>
    {

        public void Configure(EntityTypeBuilder<DocumentItem> builder)
        {

            builder.HasOne(ci => ci.Type)
                .WithOne()
                .HasForeignKey<DocumentItem>(ci => ci.IdType);

        }
    }
}
