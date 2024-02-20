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
    public partial class Сотрудник
    {

        private string фамилияField;

        private string имяField;

        private string отчествоField;

        private string отделениеБанкаField;

        private string филиалОтделенияБанкаField;

        private string нппField;

        /// <remarks/>
        public string Фамилия
        {
            get
            {
                return фамилияField;
            }
            set
            {
                фамилияField = value;
            }
        }

        /// <remarks/>
        public string Имя
        {
            get
            {
                return имяField;
            }
            set
            {
                имяField = value;
            }
        }

        /// <remarks/>
        public string Отчество
        {
            get
            {
                return отчествоField;
            }
            set
            {
                отчествоField = value;
            }
        }

        /// <remarks/>
        public string ОтделениеБанка
        {
            get
            {
                return отделениеБанкаField;
            }
            set
            {
                отделениеБанкаField = value;
            }
        }

        /// <remarks/>
        public string ФилиалОтделенияБанка
        {
            get
            {
                return филиалОтделенияБанкаField;
            }
            set
            {
                филиалОтделенияБанкаField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute(DataType = "integer")]
        public string Нпп
        {
            get
            {
                return нппField;
            }
            set
            {
                нппField = value;
            }
        }
    }
}
