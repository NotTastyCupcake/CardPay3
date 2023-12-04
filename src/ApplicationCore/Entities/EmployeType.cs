using System;
using System.Collections.Generic;
using System.Text;

namespace Metcom.CardPay3.ApplicationCore.Entities
{
    /// <summary>
    /// Категория населения
    /// </summary>
    public class EmployeType : BaseEntity
    {
#nullable enable
        public int? IdEmploye { get; set; }
        public virtual Employe? Employe { get; set; }
#nullable disable

        public EmployeType(int code, string name)
        {
            Code = code;
            Name = name;
        }

        public int Code { get; private set; }
        public string Name { get; private set; }



    }
}
