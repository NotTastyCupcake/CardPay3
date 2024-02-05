using Metcom.CardPay3.WpfApplication.ViewModels;
using ReactiveUI;
using Splat;
using System;
using System.Reactive.Disposables;

namespace Metcom.CardPay3.WpfApplication;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class ShellWindow : IViewFor<ShallViewModel>
{

    public ShellWindow(ShallViewModel viewModel = null)
    {
        ViewModel = viewModel ?? Locator.Current.GetService<ShallViewModel>();
        DataContext = ViewModel;

        InitializeComponent();

        this.WhenActivated(disposable =>
        {

            // Двунаправленная привязка значения позиции клапана. Конверторы значений свойства в модели и в представлении: FloatToStringConverter, StringToFloatConverter
            this.OneWayBind(this.ViewModel,
                vm => vm.Organizations,
                view => view.Organizations.ItemsSource)
            .DisposeWith(disposable);

            this.Bind(this.ViewModel,
                vm => vm.SelectedOrganization,
                view => view.Organizations.SelectedItem)
            .DisposeWith(disposable);


            /* Привязка команд к кнопкам */
            this.BindCommand(this.ViewModel,
                vm => vm.RoutingGoBackCommand,
                view => view.GoBackButton)
            .DisposeWith(disposable);

            this.BindCommand(ViewModel,
                vm => vm.RoutingCreateOrganizationCommand,
                view => view.CreateOrganization)
            .DisposeWith(disposable);

            this.BindCommand(ViewModel,
                vm => vm.DeleteOrganization,
                view => view.DeleteOrganization)
            .DisposeWith(disposable);

            // routing
            this.OneWayBind(ViewModel,
                    x => x.Router,
                    x => x.RoutedViewHost.Router)
                .DisposeWith(disposable);



        });
    }

}
