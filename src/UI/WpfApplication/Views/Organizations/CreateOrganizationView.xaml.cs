using Metcom.CardPay3.WpfApplication.ViewModels;
using ReactiveUI;
using ReactiveUI.Validation.Extensions;
using Splat;
using System;
using System.Reactive.Disposables;

namespace Metcom.CardPay3.WpfApplication.Views.Organization
{
    /// <summary>
    /// Логика взаимодействия для MenuView.xaml
    /// </summary>
    public partial class CreateOrganizationView : IViewFor<CreateOrganizationViewModel>
    {
        public CreateOrganizationView(CreateOrganizationViewModel viewModel = null)
        {
            ViewModel = viewModel ?? Locator.Current.GetService<CreateOrganizationViewModel>();
            DataContext = ViewModel;

            InitializeComponent();

            this.WhenActivated(disposable =>
            {
                this.Bind(this.ViewModel,
                    vm => vm.Name,
                    view => view.Name.Text)
                    .DisposeWith(disposable);

                this.BindValidation(this.ViewModel,
                    vm => vm.Name,
                    view => view.NameError.Content)
                    .DisposeWith(disposable);

                this.BindCommand(this.ViewModel,
                    vm => vm.CreateCommand,
                    view => view.Create
                    ).DisposeWith(disposable);

            });
        }
    }
}
