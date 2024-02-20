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
    public partial class УдостоверениеЛичности
    {

        private string видДокументаField;

        private string серияField;

        private string номерField;

        private DateTime датаВыдачиField;

        private string кемВыданField;

        private string кодПодразделенияField;

        private string кодВидаДокументаField;

        /// <remarks/>
        public string ВидДокумента
        {
            get
            {
                return видДокументаField;
            }
            set
            {
                видДокументаField = value;
            }
        }

        /// <remarks/>
        public string Серия
        {
            get
            {
                return серияField;
            }
            set
            {
                серияField = value;
            }
        }

        /// <remarks/>
        public string Номер
        {
            get
            {
                return номерField;
            }
            set
            {
                номерField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(DataType = "date")]
        public DateTime ДатаВыдачи
        {
            get
            {
                return датаВыдачиField;
            }
            set
            {
                датаВыдачиField = value;
            }
        }

        /// <remarks/>
        public string КемВыдан
        {
            get
            {
                return кемВыданField;
            }
            set
            {
                кемВыданField = value;
            }
        }

        /// <remarks/>
        public string КодПодразделения
        {
            get
            {
                return кодПодразделенияField;
            }
            set
            {
                кодПодразделенияField = value;
            }
        }

        /// <remarks/>
        public string КодВидаДокумента
        {
            get
            {
                return кодВидаДокументаField;
            }
            set
            {
                кодВидаДокументаField = value;
            }
        }
    }
}
