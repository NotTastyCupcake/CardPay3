using Castle.Core.Internal;
using DynamicData;
using Metcom.CardPay3.ApplicationCore.Entities;
using Metcom.CardPay3.ApplicationCore.Entities.AccrualAggregate;
using Metcom.CardPay3.ApplicationCore.Interfaces;
using Microsoft.Extensions.Logging;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using ReactiveUI.Validation.Extensions;
using ReactiveUI.Validation.Helpers;
using Splat;
using System;
using System.Reactive;
using System.Xml.Linq;

namespace Metcom.CardPay3.WpfApplication.ViewModels.Organizations
{
    public class CreateOrganizationViewModel : OrganizationViewModel, IRoutableViewModel
    {
        public string UrlPathSegment { get { return "CreateOrganization"; } }
        public IScreen HostScreen { get; protected set; }

        public CreateOrganizationViewModel(
            ILogger<CreateOrganizationViewModel> logger,
            IRepository<Organization> repositoryOrganization,
            IScreen screen = null
            ) : base (logger, repositoryOrganization)
        {
            HostScreen = screen;

            CreateCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                await _repositoryOrganization.AddAsync(Organization);
                await _repositoryOrganization.SaveChangesAsync();

                var home = Locator.Current.GetService<ShallViewModel>();
                home.Organizations.Add(Organization);
                home.SelectedOrganization = Organization;

                if (HostScreen.Router.NavigationStack.Count == 1)
                {
                    HostScreen.Router.Navigate.Execute(Locator.Current.GetService<MenuViewModel>());
                    HostScreen.Router.NavigationStack.Remove(this);
                }
                else
                {
                    HostScreen.Router.NavigateBack.Execute();
                }

            }, this.IsValid());

        }

        public ReactiveCommand<Unit, Unit> CreateCommand { get; set; }


    }
}