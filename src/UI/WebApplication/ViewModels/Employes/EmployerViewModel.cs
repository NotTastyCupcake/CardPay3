using System.Collections.Generic;

namespace Metcom.CardPay3.WebApplication.ViewModels.Employes
{
    public class EmployerViewModel
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string FullName => $"{LastName} {FirstName} {MiddleName ?? ""}";

        public string PhoneNumber { get; set; }
        public string JobPhoneNumber { get; set; }
        public string Position { get; set; }
        public string DepartmentNum { get; set; }
        public string NameOrganization { get; set; }

        #region Ссылка на объект
        public EmployeGenderViewModel Gender { get; set; }
#nullable enable
        /// <summary>
        /// Реквизиты документов человека
        /// </summary>
        public virtual ICollection<EmployeRequisitesViewModel>? Requisites { get; set; }

        public virtual ICollection<EmployeAddressViewModel>? Addresses { get; set; }
#nullable disable
        #endregion
    }
}
