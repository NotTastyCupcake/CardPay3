using Metcom.CardPay3.ApplicationCore.Entities;
using Metcom.CardPay3.WpfApplication.ViewModels.Employes;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Splat;
using System;
using System.Reactive;
using System.Reactive.Linq;

namespace Metcom.CardPay3.WpfApplication.ViewModels
{
    public class MenuViewModel : ReactiveObject, IRoutableViewModel
    {
        public string UrlPathSegment { get { return "Menu"; } }
        public IScreen HostScreen { get; protected set; }
        public MenuViewModel(IScreen screen = null)
        {
            HostScreen = screen;

            RoutingEmployeeCommand = ReactiveCommand.CreateFromTask(async delegate()
            {
                var vm = Locator.Current.GetService<EmployeeListViewModel>();
                await vm.InitializeAsync();
                await HostScreen.Router.Navigate.Execute(vm);
            });

        }
        #region commands
        public ReactiveCommand<Unit, Unit> RoutingEmployeeCommand { get; }
        public ReactiveCommand<Unit, Unit> RoutingAccrualCommand { get; }
        #endregion
    }
}
