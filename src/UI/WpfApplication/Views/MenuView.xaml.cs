using Metcom.CardPay3.WpfApplication.ViewModels;
using ReactiveUI;
using Splat;
using System;
using System.Reactive.Disposables;

namespace Metcom.CardPay3.WpfApplication.Views
{
    /// <summary>
    /// Логика взаимодействия для MenuView.xaml
    /// </summary>
    public partial class MenuView : IViewFor<MenuViewModel>
    {
        public MenuView(MenuViewModel viewModel = null)
        {
            ViewModel = viewModel ?? Locator.Current.GetService<MenuViewModel>();
            DataContext = ViewModel;

            InitializeComponent();
            this.WhenActivated(disposable =>
            {
                /* Привязка команд к кнопкам */
                this.BindCommand(this.ViewModel,
                    vm => vm.RoutingEmployeeCommand,
                    view => view.EmployeeListButton)
                    .DisposeWith(disposable);

                this.BindCommand(this.ViewModel,
                    vm => vm.RoutingOneCCommand,
                    view => view.OneCButton)
                    .DisposeWith(disposable);
            });



        }
    }
}
