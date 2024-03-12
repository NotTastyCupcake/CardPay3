using Metcom.CardPay3.ApplicationCore.Entities;
using Metcom.CardPay3.ApplicationCore.Interfaces.ServicesInterfaces.Builder;
using Metcom.CardPay3.ApplicationCore.Interfaces;
using Metcom.CardPay3.WpfApplication.Interfaces;
using Microsoft.Extensions.Logging;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive;
using Splat;
using Metcom.CardPay3.Infrastructure.Data;
using Metcom.CardPay3.WpfApplication.ViewModels.Employes.DocumentCRUD;
using System.Reactive.Linq;

namespace Metcom.CardPay3.WpfApplication.ViewModels.Employes
{
    public class EditEmployeeViewModel : EmployeeViewModel, IRoutableViewModel
    {
        public string UrlPathSegment { get { return "EditEmployee"; } }
        private readonly IRepository<Employee> _repository;

        public EditEmployeeViewModel(
            IRepository<Gender> genderRepo,
            IRepository<EmployeeType> employeeType,
            ILogger<CreateEmployeeViewModel> logger,
            IEmployeeViewModelService viewModelService,
            IEmployeeCollectionService collectionService,
            IEmployeeBuilder builder,
            IRepository<Employee> repository,
            IScreen screen = null) : base(genderRepo, employeeType, logger, viewModelService, builder, screen)
        {
            _repository = repository;

            #region Commands

            EditEmployeeCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                await repository.UpdateAsync(Employee);
                await repository.SaveChangesAsync();
                await HostScreen.Router.NavigateBack.Execute();
                await collectionService.LoadOrUpdateEmployeesCollection();

            }, this.IsValid);

            #endregion
        }

        #region Commands
        public ReactiveCommand<Unit, Unit> EditEmployeeCommand { get; }
        #endregion

    }
}
