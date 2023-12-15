using System;
using System.Collections.Generic;
using System.Text;

namespace Metcom.CardPay3.ApplicationCore.Entities
{
    /// <summary>
    /// Категория населения
    /// </summary>
    public class EmployeeType : BaseEntity
    {
#nullable enable
        public int? IdEmploye { get; set; }
        public virtual Employee? Employee { get; set; }
#nullable disable

        public EmployeeType(int code, string name)
        {
            Code = code;
            Name = name;
        }

        public int Code { get; private set; }
        public string Name { get; private set; }



    }
}
