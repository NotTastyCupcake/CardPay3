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
    [System.Xml.Serialization.XmlType(Namespace = "http://v8.1c.ru/edi/edi_stnd/109")]
    public enum Результат
    {

        /// <remarks/>
        счетОткрыт,

        /// <remarks/>
        счетНеОткрыт,

        /// <remarks/>
        ОшибкаЗаполненияДанных,

        /// <remarks/>
        зачислено,

        /// <remarks/>
        ошибкаВФИО,

        /// <remarks/>
        счетОтсутствует,

        /// <remarks/>
        счетЗакрыт,

        /// <remarks/>
        неЗачислено,
    }
}
