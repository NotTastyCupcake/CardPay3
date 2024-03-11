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
    public partial class ОткрытиеСчетов
    {

        private ОткрытиеСчетовСотрудник[] сотрудникField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("Сотрудник")]
        public ОткрытиеСчетовСотрудник[] Сотрудник
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
    public partial class ОткрытиеСчетовСотрудник : Сотрудник
    {

        private ВидВклада видВкладаField;

        private УдостоверениеЛичности удостоверениеЛичностиField;

        private DateTime датаРожденияField;

        private string полField;

        private Адрес адресМестаРаботыField;

        private string должностьField;

        private Адрес местоРожденияField;

        private Адрес адресПропискиField;

        private Адрес адресПроживанияField;

        private string[] рабочийТелефонField;

        private string[] домашнийТелефонField;

        private ОткрытиеСчетовСотрудникЭмбоссированныйТекст? эмбоссированныйТекстField;

        private decimal суммаField;

        private bool суммаFieldSpecified;

        private string кодВалютыField;

        private string признакЗарплатныйField;

        private bool резидентField;

        private string гражданствоField;

        private string категорияНаселенияField;

        private string бонусУчастникаField;

        private decimal тарифСледующийГодField;

        private bool тарифСледующийГодFieldSpecified;

        private decimal тарифТекущийГодField;

        private bool тарифТекущийГодFieldSpecified;

        private string бонусПрограммаField;

        private string признакРассылкиField;

        private string интернетАдресField;

        private string счетДебетаField;

        private string мобильныйТелефонField;

        private string операторСвязиField;

        private string мобильныйБанкField;

        private bool передачаБКИField;

        private bool передачаБКИFieldSpecified;

        private string контрольнаяИнформацияField;

        private ОткрытиеСчетовСотрудникНерезидент нерезидентField;

        private string табельныйНомерField;

        private DateTime датаОформленияField;

        private bool датаОформленияFieldSpecified;

        private decimal суммаЗаработнойПлатыField;

        private bool суммаЗаработнойПлатыFieldSpecified;

        private DateTime датаВыплатыField;

        private bool датаВыплатыFieldSpecified;

        private Адрес адресИнформированияField;

        private string идентификаторДизайнаField;

        private string пВКField;

        private string контактныйМобильныйТелефонField;

        private ОткрытиеСчетовСотрудникПриложениеКарта приложениеКартаField;

        private string сНИЛСField;

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
        public DateTime ДатаРождения
        {
            get
            {
                return датаРожденияField;
            }
            set
            {
                датаРожденияField = value;
            }
        }

        /// <remarks/>
        public string Пол
        {
            get
            {
                return полField;
            }
            set
            {
                полField = value;
            }
        }

        /// <remarks/>
        public Адрес АдресМестаРаботы
        {
            get
            {
                return адресМестаРаботыField;
            }
            set
            {
                адресМестаРаботыField = value;
            }
        }

        /// <remarks/>
        public string Должность
        {
            get
            {
                return должностьField;
            }
            set
            {
                должностьField = value;
            }
        }

        /// <remarks/>
        public Адрес МестоРождения
        {
            get
            {
                return местоРожденияField;
            }
            set
            {
                местоРожденияField = value;
            }
        }

        /// <remarks/>
        public Адрес АдресПрописки
        {
            get
            {
                return адресПропискиField;
            }
            set
            {
                адресПропискиField = value;
            }
        }

        /// <remarks/>
        public Адрес АдресПроживания
        {
            get
            {
                return адресПроживанияField;
            }
            set
            {
                адресПроживанияField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("РабочийТелефон")]
        public string[] РабочийТелефон
        {
            get
            {
                return рабочийТелефонField;
            }
            set
            {
                рабочийТелефонField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("ДомашнийТелефон")]
        public string[] ДомашнийТелефон
        {
            get
            {
                return домашнийТелефонField;
            }
            set
            {
                домашнийТелефонField = value;
            }
        }

        /// <remarks/>
        public ОткрытиеСчетовСотрудникЭмбоссированныйТекст? ЭмбоссированныйТекст
        {
            get
            {
                return эмбоссированныйТекстField;
            }
            set
            {
                эмбоссированныйТекстField = value;
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
        public string ПризнакЗарплатный
        {
            get
            {
                return признакЗарплатныйField;
            }
            set
            {
                признакЗарплатныйField = value;
            }
        }

        /// <remarks/>
        public bool Резидент
        {
            get
            {
                return резидентField;
            }
            set
            {
                резидентField = value;
            }
        }

        /// <remarks/>
        public string Гражданство
        {
            get
            {
                return гражданствоField;
            }
            set
            {
                гражданствоField = value;
            }
        }

        /// <remarks/>
        public string КатегорияНаселения
        {
            get
            {
                return категорияНаселенияField;
            }
            set
            {
                категорияНаселенияField = value;
            }
        }

        /// <remarks/>
        public string БонусУчастника
        {
            get
            {
                return бонусУчастникаField;
            }
            set
            {
                бонусУчастникаField = value;
            }
        }

        /// <remarks/>
        public decimal ТарифСледующийГод
        {
            get
            {
                return тарифСледующийГодField;
            }
            set
            {
                тарифСледующийГодField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnore()]
        public bool ТарифСледующийГодSpecified
        {
            get
            {
                return тарифСледующийГодFieldSpecified;
            }
            set
            {
                тарифСледующийГодFieldSpecified = value;
            }
        }

        /// <remarks/>
        public decimal ТарифТекущийГод
        {
            get
            {
                return тарифТекущийГодField;
            }
            set
            {
                тарифТекущийГодField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnore()]
        public bool ТарифТекущийГодSpecified
        {
            get
            {
                return тарифТекущийГодFieldSpecified;
            }
            set
            {
                тарифТекущийГодFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string БонусПрограмма
        {
            get
            {
                return бонусПрограммаField;
            }
            set
            {
                бонусПрограммаField = value;
            }
        }

        /// <remarks/>
        public string ПризнакРассылки
        {
            get
            {
                return признакРассылкиField;
            }
            set
            {
                признакРассылкиField = value;
            }
        }

        /// <remarks/>
        public string ИнтернетАдрес
        {
            get
            {
                return интернетАдресField;
            }
            set
            {
                интернетАдресField = value;
            }
        }

        /// <remarks/>
        public string СчетДебета
        {
            get
            {
                return счетДебетаField;
            }
            set
            {
                счетДебетаField = value;
            }
        }

        /// <remarks/>
        public string МобильныйТелефон
        {
            get
            {
                return мобильныйТелефонField;
            }
            set
            {
                мобильныйТелефонField = value;
            }
        }

        /// <remarks/>
        public string ОператорСвязи
        {
            get
            {
                return операторСвязиField;
            }
            set
            {
                операторСвязиField = value;
            }
        }

        /// <remarks/>
        public string МобильныйБанк
        {
            get
            {
                return мобильныйБанкField;
            }
            set
            {
                мобильныйБанкField = value;
            }
        }

        /// <remarks/>
        public bool ПередачаБКИ
        {
            get
            {
                return передачаБКИField;
            }
            set
            {
                передачаБКИField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnore()]
        public bool ПередачаБКИSpecified
        {
            get
            {
                return передачаБКИFieldSpecified;
            }
            set
            {
                передачаБКИFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string КонтрольнаяИнформация
        {
            get
            {
                return контрольнаяИнформацияField;
            }
            set
            {
                контрольнаяИнформацияField = value;
            }
        }

        /// <remarks/>
        public ОткрытиеСчетовСотрудникНерезидент Нерезидент
        {
            get
            {
                return нерезидентField;
            }
            set
            {
                нерезидентField = value;
            }
        }

        /// <remarks/>
        public string ТабельныйНомер
        {
            get
            {
                return табельныйНомерField;
            }
            set
            {
                табельныйНомерField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(DataType = "date")]
        public DateTime ДатаОформления
        {
            get
            {
                return датаОформленияField;
            }
            set
            {
                датаОформленияField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnore()]
        public bool ДатаОформленияSpecified
        {
            get
            {
                return датаОформленияFieldSpecified;
            }
            set
            {
                датаОформленияFieldSpecified = value;
            }
        }

        /// <remarks/>
        public decimal СуммаЗаработнойПлаты
        {
            get
            {
                return суммаЗаработнойПлатыField;
            }
            set
            {
                суммаЗаработнойПлатыField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnore()]
        public bool СуммаЗаработнойПлатыSpecified
        {
            get
            {
                return суммаЗаработнойПлатыFieldSpecified;
            }
            set
            {
                суммаЗаработнойПлатыFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(DataType = "date")]
        public DateTime ДатаВыплаты
        {
            get
            {
                return датаВыплатыField;
            }
            set
            {
                датаВыплатыField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnore()]
        public bool ДатаВыплатыSpecified
        {
            get
            {
                return датаВыплатыFieldSpecified;
            }
            set
            {
                датаВыплатыFieldSpecified = value;
            }
        }

        /// <remarks/>
        public Адрес АдресИнформирования
        {
            get
            {
                return адресИнформированияField;
            }
            set
            {
                адресИнформированияField = value;
            }
        }

        /// <remarks/>
        public string ИдентификаторДизайна
        {
            get
            {
                return идентификаторДизайнаField;
            }
            set
            {
                идентификаторДизайнаField = value;
            }
        }

        /// <remarks/>
        public string ПВК
        {
            get
            {
                return пВКField;
            }
            set
            {
                пВКField = value;
            }
        }

        /// <remarks/>
        public string КонтактныйМобильныйТелефон
        {
            get
            {
                return контактныйМобильныйТелефонField;
            }
            set
            {
                контактныйМобильныйТелефонField = value;
            }
        }

        /// <remarks/>
        public ОткрытиеСчетовСотрудникПриложениеКарта ПриложениеКарта
        {
            get
            {
                return приложениеКартаField;
            }
            set
            {
                приложениеКартаField = value;
            }
        }

        /// <remarks/>
        public string СНИЛС
        {
            get
            {
                return сНИЛСField;
            }
            set
            {
                сНИЛСField = value;
            }
        }
    }


    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://v8.1c.ru/edi/edi_stnd/109")]
    public partial class ОткрытиеСчетовСотрудникЭмбоссированныйТекст
    {

        private string поле1Field;

        private string поле2Field;

        private string поле3Field;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Поле1
        {
            get
            {
                return this.поле1Field;
            }
            set
            {
                this.поле1Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Поле2
        {
            get
            {
                return this.поле2Field;
            }
            set
            {
                this.поле2Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Поле3
        {
            get
            {
                return this.поле3Field;
            }
            set
            {
                this.поле3Field = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://v8.1c.ru/edi/edi_stnd/109")]
    public partial class ОткрытиеСчетовСотрудникНерезидент
    {

        private ОткрытиеСчетовСотрудникНерезидентМиграционнаяКарта миграционнаяКартаField;

        private ОткрытиеСчетовСотрудникНерезидентМиграционныйДокумент миграционныйДокументField;

        /// <remarks/>
        public ОткрытиеСчетовСотрудникНерезидентМиграционнаяКарта МиграционнаяКарта
        {
            get
            {
                return this.миграционнаяКартаField;
            }
            set
            {
                this.миграционнаяКартаField = value;
            }
        }

        /// <remarks/>
        public ОткрытиеСчетовСотрудникНерезидентМиграционныйДокумент МиграционныйДокумент
        {
            get
            {
                return this.миграционныйДокументField;
            }
            set
            {
                this.миграционныйДокументField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://v8.1c.ru/edi/edi_stnd/109")]
    public partial class ОткрытиеСчетовСотрудникНерезидентМиграционнаяКарта
    {

        private string номерField;

        private System.DateTime датаНачалаПребыванияField;

        private System.DateTime датаОкончанияПребыванияField;

        /// <remarks/>
        public string Номер
        {
            get
            {
                return this.номерField;
            }
            set
            {
                this.номерField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime ДатаНачалаПребывания
        {
            get
            {
                return this.датаНачалаПребыванияField;
            }
            set
            {
                this.датаНачалаПребыванияField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime ДатаОкончанияПребывания
        {
            get
            {
                return this.датаОкончанияПребыванияField;
            }
            set
            {
                this.датаОкончанияПребыванияField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://v8.1c.ru/edi/edi_stnd/109")]
    public partial class ОткрытиеСчетовСотрудникНерезидентМиграционныйДокумент
    {

        private string кодДокументаField;

        private string номерДокументаField;

        private System.DateTime датаНачалаПребыванияField;

        private System.DateTime датаОкончанияПребыванияField;

        /// <remarks/>
        public string КодДокумента
        {
            get
            {
                return this.кодДокументаField;
            }
            set
            {
                this.кодДокументаField = value;
            }
        }

        /// <remarks/>
        public string НомерДокумента
        {
            get
            {
                return this.номерДокументаField;
            }
            set
            {
                this.номерДокументаField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime ДатаНачалаПребывания
        {
            get
            {
                return this.датаНачалаПребыванияField;
            }
            set
            {
                this.датаНачалаПребыванияField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime ДатаОкончанияПребывания
        {
            get
            {
                return this.датаОкончанияПребыванияField;
            }
            set
            {
                this.датаОкончанияПребыванияField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://v8.1c.ru/edi/edi_stnd/109")]
    public partial class ОткрытиеСчетовСотрудникПриложениеКарта
    {

        private ОткрытиеСчетовСотрудникПриложениеКартаКод кодField;

        private string параметрField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ОткрытиеСчетовСотрудникПриложениеКартаКод Код
        {
            get
            {
                return this.кодField;
            }
            set
            {
                this.кодField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Параметр
        {
            get
            {
                return this.параметрField;
            }
            set
            {
                this.параметрField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://v8.1c.ru/edi/edi_stnd/109")]
    public enum ОткрытиеСчетовСотрудникПриложениеКартаКод
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("1")]
        Item1,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("2")]
        Item2,
    }
}
