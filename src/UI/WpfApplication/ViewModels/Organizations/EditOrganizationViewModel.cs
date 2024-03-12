using Metcom.CardPay3.ApplicationCore.Entities;
using Metcom.CardPay3.ApplicationCore.Interfaces;
using Microsoft.Extensions.Logging;
using ReactiveUI;
using ReactiveUI.Validation.Extensions;
using Splat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.WpfApplication.ViewModels.Organizations
{
    public class EditOrganizationViewModel : OrganizationViewModel, IRoutableViewModel
    {
        public string UrlPathSegment { get { return "EditOrganization"; } }
        public IScreen HostScreen { get; protected set; }

        public EditOrganizationViewModel(
            ILogger<EditOrganizationViewModel> logger,
            IRepository<Organization> repositoryOrganization,
            IScreen screen = null
            ) : base(logger, repositoryOrganization)
        {
            HostScreen = screen;

            EditCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                await _repositoryOrganization.UpdateAsync(Organization);
                await _repositoryOrganization.SaveChangesAsync();

                if (HostScreen.Router.NavigationStack.Count == 1)
                {
                    await HostScreen.Router.Navigate.Execute(Locator.Current.GetService<MenuViewModel>());
                    HostScreen.Router.NavigationStack.Remove(this);
                }
                else
                {
                    await HostScreen.Router.NavigateBack.Execute();
                }

            }, this.IsValid());
        }

        public ReactiveCommand<Unit, Unit> EditCommand { get; set; }
    }
}
