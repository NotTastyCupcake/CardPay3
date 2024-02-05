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

namespace Metcom.CardPay3.WpfApplication.ViewModels.Employes
{
    
    public class CreateEmployeeViewModel : EmployeeViewModel, IRoutableViewModel
    {
        public string UrlPathSegment { get { return "CreateEmployee"; } }
        public IScreen HostScreen { get; protected set; }

        public CreateEmployeeViewModel(
            IRepository<Gender> genderRepo,
            IRepository<EmployeeType> employeeType,
            ILogger<CreateEmployeeViewModel> logger,
            IEmployeeViewModelService viewModelService,
            IEmployeeBuilder builder,
            IScreen screen = null) : base(genderRepo, employeeType, logger, viewModelService, builder)
        {
            HostScreen = screen;

            #region Commands

            CreateEmployeeCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                await _builder.SetOrganization(Locator.Current.GetService<ShallViewModel>().SelectedOrganization.Id);
                await _builder.SetGender(Gender.Id);
                await _builder.SetDocument(Document);
                await _builder.SetEmployee(this);

                HostScreen.Router.NavigateBack.Execute();

            }, this.IsValid);

            CreateDocumentCommand = ReactiveCommand.Create(delegate ()
            {
                var vm = Locator.Current.GetService<CreateDocumentViewModel>();
                HostScreen.Router.Navigate.Execute(vm);
                vm.WhenAnyValue(vm => vm.Document).Subscribe(_ => Document = _);
            });

            #endregion
        }


        #region Commands
        public ReactiveCommand<Unit, Unit> CreateEmployeeCommand { get; }
        public ReactiveCommand<Unit, Unit> CreateDocumentCommand { get; }
        #endregion

    }
}
