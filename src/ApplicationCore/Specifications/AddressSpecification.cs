﻿using Ardalis.Specification;
using Metcom.CardPay3.ApplicationCore.Entities;
using Metcom.CardPay3.ApplicationCore.Entities.AccrualAggregate;
using Metcom.CardPay3.ApplicationCore.Entities.AddressAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Metcom.CardPay3.ApplicationCore.Specifications
{
    public sealed class AddressSpecification : Specification<Address>, ISingleResultSpecification<Address>
    {
        public AddressSpecification(string fullName)
        {
            Query
                .Where(a => a.FullName == fullName);
        }

        public AddressSpecification(IAddress address)
        {
            Query
                .Where(a => a.FullName == address.FullName);
        }

        public AddressSpecification(IEmployee employee)
        {
            Query
                .Where (a => a.Employee == employee);
        }
    }
}
