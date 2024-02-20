using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.Integration.Models.OneC
{

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCode("xsd", "2.0.50727.3038")]
    [Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(Namespace = "http://v8.1c.ru/edi/edi_stnd/109")]
    public partial class РезультатОткрытияСчетов
    {

        private РезультатОткрытияСчетовСотрудник[] сотрудникField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("Сотрудник")]
        public РезультатОткрытияСчетовСотрудник[] Сотрудник
        {
            get
            {
                return сотрудникField;
            }
            set
            {
                сотрудникField = value;
            }
        }
    }


    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCode("xsd", "2.0.50727.3038")]
    [Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://v8.1c.ru/edi/edi_stnd/109")]
    public partial class РезультатОткрытияСчетовСотрудник : Сотрудник
    {

        private string лицевойСчетField;

        private decimal суммаField;

        private bool суммаFieldSpecified;

        private string кодВалютыField;

        private УдостоверениеЛичности удостоверениеЛичностиField;

        private DateTime действительноДоField;

        private bool действительноДоFieldSpecified;

        private Результат результатField;

        private ВидВклада видВкладаField;

        private string расшифровкаРезультатаField;

        private string номерКартыField;

        private string бИКField;

        /// <remarks/>
        public string ЛицевойСчет
        {
            get
            {
                return лицевойСчетField;
            }
            set
            {
                лицевойСчетField = value;
            }
        }

        /// <remarks/>
        public decimal Сумма
        {
            get
            {
                return суммаField;
            }
            set
            {
                суммаField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnore()]
        public bool СуммаSpecified
        {
            get
            {
                return суммаFieldSpecified;
            }
            set
            {
                суммаFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string КодВалюты
        {
            get
            {
                return кодВалютыField;
            }
            set
            {
                кодВалютыField = value;
            }
        }

        /// <remarks/>
        public УдостоверениеЛичности УдостоверениеЛичности
        {
            get
            {
                return удостоверениеЛичностиField;
            }
            set
            {
                удостоверениеЛичностиField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(DataType = "date")]
        public DateTime ДействительноДо
        {
            get
            {
                return действительноДоField;
            }
            set
            {
                действительноДоField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnore()]
        public bool ДействительноДоSpecified
        {
            get
            {
                return действительноДоFieldSpecified;
            }
            set
            {
                действительноДоFieldSpecified = value;
            }
        }

        /// <remarks/>
        public Результат Результат
        {
            get
            {
                return результатField;
            }
            set
            {
                результатField = value;
            }
        }

        /// <remarks/>
        public ВидВклада ВидВклада
        {
            get
            {
                return видВкладаField;
            }
            set
            {
                видВкладаField = value;
            }
        }

        /// <remarks/>
        public string РасшифровкаРезультата
        {
            get
            {
                return расшифровкаРезультатаField;
            }
            set
            {
                расшифровкаРезультатаField = value;
            }
        }

        /// <remarks/>
        public string НомерКарты
        {
            get
            {
                return номерКартыField;
            }
            set
            {
                номерКартыField = value;
            }
        }

        /// <remarks/>
        public string БИК
        {
            get
            {
                return бИКField;
            }
            set
            {
                бИКField = value;
            }
        }
    }
}
