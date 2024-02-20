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
    public partial class СписокУвольнений
    {

        private СписокУвольненийСотрудник[] сотрудникField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("Сотрудник")]
        public СписокУвольненийСотрудник[] Сотрудник
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
    public partial class СписокУвольненийСотрудник : Сотрудник
    {

        private string номерСчетаField;

        private DateTime датаУвольненияField;

        private string номерКартыField;

        /// <remarks/>
        public string НомерСчета
        {
            get
            {
                return номерСчетаField;
            }
            set
            {
                номерСчетаField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(DataType = "date")]
        public DateTime ДатаУвольнения
        {
            get
            {
                return датаУвольненияField;
            }
            set
            {
                датаУвольненияField = value;
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
    }
}
