using Metcom.CardPay3.WpfApplication.ViewModels.Organizations;
using ReactiveUI;
using ReactiveUI.Validation.Extensions;
using Splat;
using System;
using System.Reactive.Disposables;

namespace Metcom.CardPay3.WpfApplication.Views.Organization
{
    public partial class CreateOrganizationView
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
                    view => view.NameOrg.Text)
                    .DisposeWith(disposable);

                this.BindValidation(this.ViewModel,
                    vm => vm.Name,
                    view => view.NameError.Content)
                    .DisposeWith(disposable);


                this.Bind(this.ViewModel,
                    vm => vm.SelectedCreateDate,
                    view => view.CreateDate.SelectedDate)
                    .DisposeWith(disposable);

                this.BindValidation(this.ViewModel,
                    vm => vm.SelectedCreateDate,
                    view => view.CreateDateError.Content)
                    .DisposeWith(disposable);


                this.Bind(this.ViewModel,
                    vm => vm.INN,
                    view => view.INN.Text)
                    .DisposeWith(disposable);

                this.BindValidation(this.ViewModel,
                    vm => vm.INN,
                    view => view.INNError.Content)
                    .DisposeWith(disposable);



                this.Bind(this.ViewModel,
                    vm => vm.ApplicationNumber,
                    view => view.AppNumber.Text)
                    .DisposeWith(disposable);

                this.BindValidation(this.ViewModel,
                    vm => vm.ApplicationNumber,
                    view => view.AppNumberError.Content)
                    .DisposeWith(disposable);



                this.Bind(this.ViewModel,
                    vm => vm.SelectedApplicationDate,
                    view => view.AppDate.SelectedDate)
                    .DisposeWith(disposable);

                this.BindValidation(this.ViewModel,
                    vm => vm.SelectedApplicationDate,
                    view => view.AppDateError.Content)
                    .DisposeWith(disposable);



                this.Bind(this.ViewModel,
                    vm => vm.Account,
                    view => view.Account.Text)
                    .DisposeWith(disposable);

                this.BindValidation(this.ViewModel,
                    vm => vm.Account,
                    view => view.AccountError.Content)
                    .DisposeWith(disposable);



                this.Bind(this.ViewModel,
                    vm => vm.BankCode,
                    view => view.BankCode.Text)
                    .DisposeWith(disposable);

                this.BindValidation(this.ViewModel,
                    vm => vm.ApplicationNumber,
                    view => view.AppNumberError.Content)
                    .DisposeWith(disposable);



                this.Bind(this.ViewModel,
                    vm => vm.SourceId,
                    view => view.SourceId.Text)
                    .DisposeWith(disposable);

                this.BindValidation(this.ViewModel,
                    vm => vm.SourceId,
                    view => view.SourceIdError.Content)
                    .DisposeWith(disposable);



                this.BindCommand(this.ViewModel,
                    vm => vm.CreateCommand,
                    view => view.Create
                    ).DisposeWith(disposable);

            });
        }

    }
}
