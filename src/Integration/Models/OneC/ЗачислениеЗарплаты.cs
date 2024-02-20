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
    public class ЗачислениеЗарплаты
    {

        private ЗачислениеЗарплатыСотрудник[] сотрудникField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("Сотрудник")]
        public ЗачислениеЗарплатыСотрудник[] Сотрудник
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
    public class ЗачислениеЗарплатыСотрудник : Сотрудник
    {

        private string идентификаторПлатежаField;

        private string itemField;

        private ItemChoiceType itemElementNameField;

        private decimal суммаField;

        private string кодВалютыField;

        private decimal общаяСуммаУдержанийField;

        private bool общаяСуммаУдержанийFieldSpecified;

        private string бИКField;

        /// <remarks/>
        public string ИдентификаторПлатежа
        {
            get
            {
                return идентификаторПлатежаField;
            }
            set
            {
                идентификаторПлатежаField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("ЛицевойСчет", typeof(string))]
        [System.Xml.Serialization.XmlElement("НомерКарты", typeof(string))]
        [System.Xml.Serialization.XmlElement("НомерТелефона", typeof(string))]
        [System.Xml.Serialization.XmlElement("СНИЛС", typeof(string))]
        [System.Xml.Serialization.XmlChoiceIdentifier("ItemElementName")]
        public string Item
        {
            get
            {
                return itemField;
            }
            set
            {
                itemField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnore()]
        public ItemChoiceType ItemElementName
        {
            get
            {
                return itemElementNameField;
            }
            set
            {
                itemElementNameField = value;
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
        public decimal ОбщаяСуммаУдержаний
        {
            get
            {
                return общаяСуммаУдержанийField;
            }
            set
            {
                общаяСуммаУдержанийField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnore()]
        public bool ОбщаяСуммаУдержанийSpecified
        {
            get
            {
                return общаяСуммаУдержанийFieldSpecified;
            }
            set
            {
                общаяСуммаУдержанийFieldSpecified = value;
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

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCode("xsd", "2.0.50727.3038")]
    [Serializable()]
    [System.Xml.Serialization.XmlType(Namespace = "http://v8.1c.ru/edi/edi_stnd/109", IncludeInSchema = false)]
    public enum ItemChoiceType
    {

        /// <remarks/>
        ЛицевойСчет,

        /// <remarks/>
        НомерКарты,

        /// <remarks/>
        НомерТелефона,

        /// <remarks/>
        СНИЛС,
    }
}
