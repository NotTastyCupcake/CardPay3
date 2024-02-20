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
    public partial class ВидВклада
    {

        private string кодВидаВкладаField;

        private string кодПодвидаВкладаField;

        private string кодВалютыField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string КодВидаВклада
        {
            get
            {
                return кодВидаВкладаField;
            }
            set
            {
                кодВидаВкладаField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string КодПодвидаВклада
        {
            get
            {
                return кодПодвидаВкладаField;
            }
            set
            {
                кодПодвидаВкладаField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
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
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
            }
        }
    }

}
