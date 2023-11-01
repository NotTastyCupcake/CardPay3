using Castle.Core.Logging;
using Metcom.CardPay3.ApplicationCore.Entities;
using Metcom.CardPay3.ApplicationCore.Entities.AddressAggregate;
using Metcom.CardPay3.ApplicationCore.Entities.DocumentAggregate;
using Metcom.CardPay3.ApplicationCore.Entities.RequisitesAggtegate;
using Metcom.CardPay3.ApplicationCore.Interfaces;
using Metcom.CardPay3.ApplicationCore.Interfaces.ServicesInterfaces;
using Metcom.CardPay3.ApplicationCore.Specifications;
using Metcom.CardPay3.WpfApplication.Interfaces;
using Metcom.CardPay3.WpfApplication.Views.Employes;
using Microsoft.Extensions.Logging;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using ReactiveUI.Validation.Helpers;
using Splat;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reactive;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace Metcom.CardPay3.WpfApplication.ViewModels.Employes
{
    public class EmployeViewModel : ReactiveValidationObject, IRoutableViewModel
    {
        public string UrlPathSegment { get { return "AddEmployee"; } }
        public IScreen HostScreen { get; protected set; }

        private readonly IRepository<Employe> _repository;
        private readonly ILogger<EmployeViewModel> _logger;
        private readonly IEmployeViewModelService _employeViewModelService;

        public EmployeViewModel(
            IRepository<Employe> repository,
            ILogger<EmployeViewModel> logger,
            IEmployeViewModelService viewModelService,
            IScreen screen = null)
        {
            _repository = repository;
            _logger = logger;
            _employeViewModelService = viewModelService;

            HostScreen = screen;

            Organization = Locator.Current.GetService<MenuViewModel>().SelectedOrganization;

            //Window = Locator.Current.GetService<IViewFor<EmployeeViewModel>>() as Window;

            // commands
            ActionCommand = ReactiveCommand.Create(ActionAndCloseWindowAsync());

            CreateAddress = ReactiveCommand.Create(() =>
            {
                var vm = Locator.Current.GetService<AddressViewModel>();
                HostScreen.Router.Navigate.Execute(vm);
                return vm.Address;
            });

            Task.Run(() => Initialize());

            //this.WhenAnyValue(vm => vm.Employe).Subscribe(_ => /*UpdateIsRealOrganization()*/);

        }

        private Action ActionAndCloseWindowAsync()
        {
            return async delegate ()
            {
                Employe.Gender = SelectedGender;
                Employe.Document = Document;
                Employe.Addresses = Address;
                Employe.Requisites = Requisites;
                Employe.Organization = Organization;

                //Add
                if(SelectedOperation == Constants.Operations.Create)
                {
                    await _repository.AddAsync(Employe);
                    await _repository.SaveChangesAsync();
                }
                //Edit
                else if(SelectedOperation == Constants.Operations.Edit)
                {
                    await _repository.UpdateAsync(Employe);
                    await _repository.SaveChangesAsync();
                }


                HostScreen.Router.NavigateBack.Execute();
            };
        }

        private async Task Initialize()
        {
            Genders = await _employeViewModelService.GetGenders();

            if (SelectedOperation == Constants.Operations.Create)
            {
                Employe = new Employe();
            }
            else if (SelectedOperation == Constants.Operations.Edit)
            {
                SelectedGender = Employe.Gender;
                Document = Employe.Document;
                Address = await _employeViewModelService.GetAddress(Employe);
                Requisites = await _employeViewModelService.GetRequisites(Employe);
                Organization = Employe.Organization;
            }

            this.WhenAnyValue(vm => vm.Employe).Subscribe();
            this.WhenAnyValue(vm => vm.SelectedGender).Subscribe();
            this.WhenAnyValue(vm => vm.Document).Subscribe();
            this.WhenAnyValue(vm => vm.Address).Subscribe();
            this.WhenAnyValue(vm => vm.Requisites).Subscribe();
            this.WhenAnyValue(vm => vm.Organization).Subscribe();
        }


        #region commands
        public ReactiveCommand<Unit, Unit> ActionCommand { get; }
        public ReactiveCommand<Unit, DocumentItem> CreateDocument { get; }
        public ReactiveCommand<Unit, Address> CreateAddress { get; }
        #endregion

        #region properties
        [Reactive]
        public Employe Employe { get; set; }

        [Reactive]
        public Organization Organization { get; set; }
        [Reactive]
        //TODO: Убрать авто заполнение, сделать форму создания документа
        public DocumentItem Document { get; set; } = new DocumentItem(1, DateTime.Now, "TEST_ISSUEDBY", "TEST_SUBDIVISION_CODE");
        [Reactive]
        public string DocumentFullName { get; set; } = "<Нет данных>";
        [Reactive]
        public ObservableCollection<Address> Address { get; set; }
        [Reactive]
        public string AddressFullName { get; set; } = "<Нет данных>";
        [Reactive]
        public ObservableCollection<RequisitesItem> Requisites { get; set; }

        [Reactive]
        public ReadOnlyObservableCollection<Gender> Genders { get; set; }

        [Reactive]
        public Gender SelectedGender { get; set; }

        [Reactive]
        public Constants.Operations SelectedOperation { get; set; }
        #endregion
    }
}
