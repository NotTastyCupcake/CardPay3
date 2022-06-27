using Metcom.CardPay3.ApplicationCore.Entities.AddressAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.Infrastructure.Config.AddressConfig
{
    public class ResidenceAddressConfiguration : IEntityTypeConfiguration<ResidenceAddressItem>
    {
        public void Configure(EntityTypeBuilder<ResidenceAddressItem> builder)
        {
            throw new NotImplementedException();
        }
    }
}
