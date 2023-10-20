using Metcom.CardPay3.ApplicationCore.Entities;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Splat;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.WpfApplication.ViewModels
{
    public class MenuViewModel : ReactiveObject, IRoutableViewModel
    {
        public string UrlPathSegment { get { return "Menu"; } }
        public IScreen HostScreen { get; protected set; }
        public MenuViewModel(IScreen screen = null)
        {
            HostScreen = screen;

            RoutingEmployeeCommand = ReactiveCommand.Create(delegate ()
            {
                EmployeeListViewModel = Locator.Current.GetService<EmployeeListViewModel>();
                EmployeeListViewModel.SelectedOrganization = SelectedOrganization;
                HostScreen.Router.Navigate.Execute(EmployeeListViewModel);
            });

            this.WhenAnyValue(vm => vm.SelectedOrganization).Subscribe(_ => UpdateIsRealOrganization());
        }
        #region commands
        public ReactiveCommand<Unit, Unit> RoutingEmployeeCommand { get; }
        public ReactiveCommand<Unit, Unit> RoutingAccrualCommand { get; }
        #endregion

        [Reactive]
        public Organization SelectedOrganization { get; set; }
        [Reactive]
        public bool IsRealOrganization { get; set; }

        public EmployeeListViewModel EmployeeListViewModel { get; set; }

        private void UpdateIsRealOrganization()
        {
            if (SelectedOrganization == null)
            {
                IsRealOrganization = false;
            }
            else if (SelectedOrganization.Name == "Создать организацию.")
            {
                IsRealOrganization = false;
                HostScreen.Router.Navigate.Execute(Locator.Current.GetService<CreateOrganizationViewModel>());
            }
            else
            {
                IsRealOrganization = true;

                if(EmployeeListViewModel != null)
                {
                    EmployeeListViewModel.SelectedOrganization = SelectedOrganization;
                }

            }
        }
    }
}
