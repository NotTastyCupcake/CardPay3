﻿using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.ApplicationCore.Entities.AccrualAggregate
{
    public class OperationType : BaseEntity
    {
        public string Name { get; private set; }
        public OperationType(string name)
        {
            Name = name;
        }

        public OperationType()
        {
            // required by EF
        }

        public void UpdateNameGroup(string newNameOrganization)
        {
            Guard.Against.NullOrEmpty(newNameOrganization, nameof(newNameOrganization));

            Name = newNameOrganization;
        }
    }
}
