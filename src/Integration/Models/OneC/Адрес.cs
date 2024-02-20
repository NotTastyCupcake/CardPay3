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
    public partial class Адрес
    {

        private string индексField;

        private АдресСтрана странаField;

        private АдресРегион регионField;

        private АдресРайон районField;

        private АдресГород городField;

        private АдресНаселенныйПункт населенныйПунктField;

        private АдресУлица улицаField;

        private string домField;

        private string корпусField;

        private string квартираField;

        /// <remarks/>
        public string Индекс
        {
            get
            {
                return индексField;
            }
            set
            {
                индексField = value;
            }
        }

        /// <remarks/>
        public АдресСтрана Страна
        {
            get
            {
                return странаField;
            }
            set
            {
                странаField = value;
            }
        }

        /// <remarks/>
        public АдресРегион Регион
        {
            get
            {
                return регионField;
            }
            set
            {
                регионField = value;
            }
        }

        /// <remarks/>
        public АдресРайон Район
        {
            get
            {
                return районField;
            }
            set
            {
                районField = value;
            }
        }

        /// <remarks/>
        public АдресГород Город
        {
            get
            {
                return городField;
            }
            set
            {
                городField = value;
            }
        }

        /// <remarks/>
        public АдресНаселенныйПункт НаселенныйПункт
        {
            get
            {
                return населенныйПунктField;
            }
            set
            {
                населенныйПунктField = value;
            }
        }

        /// <remarks/>
        public АдресУлица Улица
        {
            get
            {
                return улицаField;
            }
            set
            {
                улицаField = value;
            }
        }

        /// <remarks/>
        public string Дом
        {
            get
            {
                return домField;
            }
            set
            {
                домField = value;
            }
        }

        /// <remarks/>
        public string Корпус
        {
            get
            {
                return корпусField;
            }
            set
            {
                корпусField = value;
            }
        }

        /// <remarks/>
        public string Квартира
        {
            get
            {
                return квартираField;
            }
            set
            {
                квартираField = value;
            }
        }
    }



    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCode("xsd", "2.0.50727.3038")]
    [Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://v8.1c.ru/edi/edi_stnd/109")]
    public partial class АдресСтрана
    {

        private string странаНазваниеField;

        private string странаСокращениеField;

        private string странаКодField;

        /// <remarks/>
        public string СтранаНазвание
        {
            get
            {
                return странаНазваниеField;
            }
            set
            {
                странаНазваниеField = value;
            }
        }

        /// <remarks/>
        public string СтранаСокращение
        {
            get
            {
                return странаСокращениеField;
            }
            set
            {
                странаСокращениеField = value;
            }
        }

        /// <remarks/>
        public string СтранаКод
        {
            get
            {
                return странаКодField;
            }
            set
            {
                странаКодField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCode("xsd", "2.0.50727.3038")]
    [Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://v8.1c.ru/edi/edi_stnd/109")]
    public partial class АдресРегион
    {

        private string регионНазваниеField;

        private string регионСокращениеField;

        /// <remarks/>
        public string РегионНазвание
        {
            get
            {
                return регионНазваниеField;
            }
            set
            {
                регионНазваниеField = value;
            }
        }

        /// <remarks/>
        public string РегионСокращение
        {
            get
            {
                return регионСокращениеField;
            }
            set
            {
                регионСокращениеField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCode("xsd", "2.0.50727.3038")]
    [Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://v8.1c.ru/edi/edi_stnd/109")]
    public partial class АдресРайон
    {

        private string районНазваниеField;

        private string районСокращениеField;

        /// <remarks/>
        public string РайонНазвание
        {
            get
            {
                return районНазваниеField;
            }
            set
            {
                районНазваниеField = value;
            }
        }

        /// <remarks/>
        public string РайонСокращение
        {
            get
            {
                return районСокращениеField;
            }
            set
            {
                районСокращениеField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCode("xsd", "2.0.50727.3038")]
    [Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://v8.1c.ru/edi/edi_stnd/109")]
    public partial class АдресГород
    {

        private string городНазваниеField;

        private string городСокращениеField;

        /// <remarks/>
        public string ГородНазвание
        {
            get
            {
                return городНазваниеField;
            }
            set
            {
                городНазваниеField = value;
            }
        }

        /// <remarks/>
        public string ГородСокращение
        {
            get
            {
                return городСокращениеField;
            }
            set
            {
                городСокращениеField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCode("xsd", "2.0.50727.3038")]
    [Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://v8.1c.ru/edi/edi_stnd/109")]
    public partial class АдресНаселенныйПункт
    {

        private string населенныйПунктНазваниеField;

        private string населенныйПунктСокращениеField;

        /// <remarks/>
        public string НаселенныйПунктНазвание
        {
            get
            {
                return населенныйПунктНазваниеField;
            }
            set
            {
                населенныйПунктНазваниеField = value;
            }
        }

        /// <remarks/>
        public string НаселенныйПунктСокращение
        {
            get
            {
                return населенныйПунктСокращениеField;
            }
            set
            {
                населенныйПунктСокращениеField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCode("xsd", "2.0.50727.3038")]
    [Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://v8.1c.ru/edi/edi_stnd/109")]
    public partial class АдресУлица
    {

        private string улицаНазваниеField;

        private string улицаСокращениеField;

        /// <remarks/>
        public string УлицаНазвание
        {
            get
            {
                return улицаНазваниеField;
            }
            set
            {
                улицаНазваниеField = value;
            }
        }

        /// <remarks/>
        public string УлицаСокращение
        {
            get
            {
                return улицаСокращениеField;
            }
            set
            {
                улицаСокращениеField = value;
            }
        }
    }
}
