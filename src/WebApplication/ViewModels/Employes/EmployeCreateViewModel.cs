using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.WebApplication.ViewModels.Employes
{
    public class EmployeCreateViewModel
    {
        #region ФИО Сотрудника
        [Required(ErrorMessage ="Введите фамилию сотрудника")]
        public string LastName { get; private set; }
        [Display(Name = "Имя")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Текст должен содержать от 2 - 20 символов")]
        [RegularExpression(@"^[а-яА-Я]{1,20}$", ErrorMessage = "Здесь должен быть текст на русском")]
        [Required(ErrorMessage = "Введите имя сотрудника")]
        public string FirstName { get; private set; }
        public string MiddleName { get; private set; }
        #endregion

        #region Контактные данные
        public string PhoneNumber { get; private set; }
        public string JobPhoneNumber { get; private set; }
        public string Position { get; private set; }
        public string DepartmentNum { get; private set; }
        #endregion

        #region Ссылка на объект
#nullable enable
        public int IdGender { get; private set; }
#nullable disable
        #endregion

        public int IdType { get; set; }

        public DateTime DataIssued { get; set; }
        public string IssuedBy { get; set; }
        public string SubdivisionCode { get; set; }
    }
}
