using Metcom.CardPay3.ApplicationCore.Entities;
using Metcom.CardPay3.ApplicationCore.Interfaces;
using Metcom.CardPay3.WpfApplication.Interfaces;
using Microsoft.Extensions.Logging;
using ReactiveUI.Validation.Helpers;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Splat;
using ReactiveUI.Fody.Helpers;
using Metcom.CardPay3.ApplicationCore.Interfaces.ServicesInterfaces.Builder;
using System.Reactive;
using System.Collections.ObjectModel;
using DynamicData;
using ReactiveUI.Validation.Extensions;
using ReactiveUI.Validation.Abstractions;
using ReactiveUI.Validation.Contexts;
using System.Windows.Forms;
using Castle.Core.Internal;
using Metcom.CardPay3.ApplicationCore.Entities.AddressAggregate;
using Metcom.CardPay3.ApplicationCore.Entities.DocumentAggregate;
using Metcom.CardPay3.ApplicationCore.Entities.RequisitesAggtegate;
using System.Reflection.Metadata;
using Metcom.CardPay3.WpfApplication.ViewModels.Employes.DocumentCRUD;
using System.Reactive.Linq;

namespace Metcom.CardPay3.WpfApplication.ViewModels.Employes
{
    
    public class CreateEmployeeViewModel : EmployeeViewModel, IRoutableViewModel
    {
        public string UrlPathSegment { get { return "CreateEmployee"; } }

        public CreateEmployeeViewModel(
            IRepository<Gender> genderRepo,
            IRepository<EmployeeType> employeeType,
            ILogger<CreateEmployeeViewModel> logger,
            IEmployeeViewModelService viewModelService,
            IEmployeeCollectionService collectionService,
            IEmployeeBuilder builder,
            IScreen screen = null) : base(genderRepo, employeeType, logger, viewModelService, builder, screen)
        {
            #region Commands

            CreateEmployeeCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                await _builder.SetOrganization(Locator.Current.GetService<ShallViewModel>().SelectedOrganization.Id);
                await _builder.SetGender(GenderSelected.Id);
                await _builder.SetDocument(DocumentViewModel);
                await _builder.SetRequisities(RequisiteViewModel);
                //await _builder.AddAddress(Addresses.FirstOrDefault());
                await _builder.SetEmployee(Employee);

                await HostScreen.Router.NavigateBack.Execute();

                await collectionService.LoadOrUpdateEmployeesCollection();

            }, this.IsValid());

            #endregion
        }


        #region Commands
        public ReactiveCommand<Unit, Unit> CreateEmployeeCommand { get; }
        #endregion

    }
}
