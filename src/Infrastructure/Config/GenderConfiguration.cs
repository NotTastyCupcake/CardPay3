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
    public class GenderConfiguration : IEntityTypeConfiguration<PersonGender>
    {
        public void Configure(EntityTypeBuilder<PersonGender> builder)
        {
            throw new NotImplementedException();
        }
    }
}
