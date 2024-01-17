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

namespace Metcom.CardPay3.WpfApplication.ViewModels
{
    public class CreateOrganizationViewModel : ReactiveValidationObject, IRoutableViewModel, IOrganization
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

            this.ValidationRule(
                viewModel => viewModel.CreateDate,
                item => item.HasValue,
                "Дата формирования должна быть заполнена обязательно");

            this.ValidationRule(
                viewModel => viewModel.ApplicationNumber,
                item => !string.IsNullOrWhiteSpace(item),
                "Номер договора должнен быть заполнен обязательно");

            this.ValidationRule(
                viewModel => viewModel.Name,
                item => !string.IsNullOrWhiteSpace(item),
                "Название должно быть заполнено обязательно");

            this.ValidationRule(
                viewModel => viewModel.SourceId,
                item => !string.IsNullOrWhiteSpace(item),
                "Ид первичного документа должно быть заполнено обязательно");

            //CreateDate = createDate;
            //ApplicationNumber = appNumber;
            //Name = name;
            //SourceId = sourceId;

            CreateCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                var item = new Organization(this);

                await _repositoryOrganization.AddAsync(item);
                await _repositoryOrganization.SaveChangesAsync();

                var home = Locator.Current.GetService<HomeViewModel>();
                home.Organizations.Add(item);
                home.SelectedOrganization = item;
                

                if(HostScreen.Router.NavigationStack.Count == 1)
                {
                    HostScreen.Router.Navigate.Execute(Locator.Current.GetService<MenuViewModel>());
                }
                else
                {
                    HostScreen.Router.NavigateBack.Execute();
                }

            }, this.IsValid());

        }

        public ReactiveCommand<Unit, Unit> CreateCommand { get; set; }

        [Reactive]
        public string Name { get; set; }

        /// <summary>
        /// Дата формирования
        /// </summary>
        [Reactive]
        public DateTime? CreateDate { get; set; }
        public string INN { get; set; }
        /// <summary>
        /// Номер договора
        /// </summary>
        [Reactive]
        public string ApplicationNumber { get; set; }
        [Reactive]
        public DateTime? ApplicationDate { get; set; }
        [Reactive]
        public string Account { get; set; }
        /// <summary>
        /// Рекомендуется заполнять. БИК банка, с которым заключен зарплатный договор
        /// </summary>
        [Reactive]
        public string BankCode { get; set; }
        /// <summary> 
        /// Ид первичного документа
        /// </summary>
        [Reactive]
        public string SourceId { get; set; }

    }
}