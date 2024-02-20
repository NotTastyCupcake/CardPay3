﻿using Metcom.CardPay3.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.ApplicationCore.Interfaces.OneC
{
    public interface IOneCService
    {
        public Task OpenAccounts(Organization employee, string path);
        public Task SaveResultOpenAccounts(Stream stream);
        public Task CloseAccounts(Organization employee, string path);
    }
}
