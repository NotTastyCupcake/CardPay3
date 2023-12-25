using Metcom.CardPay3.ApplicationCore.Entities;
using Metcom.CardPay3.ApplicationCore.Entities.AccrualAggregate;
using Metcom.CardPay3.ApplicationCore.Interfaces;
using Microsoft.Extensions.Logging;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Splat;
using System;
using System.Reactive;

namespace Metcom.CardPay3.WpfApplication.ViewModels
{
    public class CreateOrganizationViewModel : ReactiveObject, IRoutableViewModel
    {
        public string UrlPathSegment { get { return "CreateOrganization"; } }
        public IScreen HostScreen { get; protected set; }

        ILogger<CreateOrganizationViewModel> _logger;
        IRepository<Organization> _repositoryOrganization;

        public CreateOrganizationViewModel(
            ILogger<CreateOrganizationViewModel> logger,
            IRepository<Organization> repositoryOrganization,
            IScreen screen = null
            )
        {
            _logger = logger;
            _repositoryOrganization = repositoryOrganization;

            HostScreen = screen;

            CreateCommand = ReactiveCommand.Create(CreateAction());

        }

        private Action CreateAction()
        {
            return async delegate ()
            {
                var item = new Organization(Name);
                await _repositoryOrganization.AddAsync(item);
                await _repositoryOrganization.SaveChangesAsync();

                var home = Locator.Current.GetService<HomeViewModel>();
                home.Organizations.Add(item);
                home.SelectedOrganization = item;

                HostScreen.Router.NavigateBack.Execute();
            };
        }

        public ReactiveCommand<Unit, Unit> CreateCommand { get; set; }

        [Reactive]
        public string Name { get; set; }

    }
}