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
    public partial class КонтрольныеСуммы
    {

        private decimal количествоЗаписейField;

        private decimal суммаИтогоField;

        private bool суммаИтогоFieldSpecified;

        /// <remarks/>
        public decimal КоличествоЗаписей
        {
            get
            {
                return количествоЗаписейField;
            }
            set
            {
                количествоЗаписейField = value;
            }
        }

        /// <remarks/>
        public decimal СуммаИтого
        {
            get
            {
                return суммаИтогоField;
            }
            set
            {
                суммаИтогоField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnore()]
        public bool СуммаИтогоSpecified
        {
            get
            {
                return суммаИтогоFieldSpecified;
            }
            set
            {
                суммаИтогоFieldSpecified = value;
            }
        }
    }
}
