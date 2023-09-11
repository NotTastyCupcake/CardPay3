﻿using Castle.Core.Logging;
using Metcom.CardPay3.ApplicationCore.Entities.AddressAggregate;
using Metcom.CardPay3.ApplicationCore.Interfaces;
using Microsoft.Extensions.Logging;
using ReactiveUI;
using System;
using System.ComponentModel;
using System.Reactive;

namespace Metcom.CardPay3.WpfApplication.ViewModels.Employes
{
    public class AddressViewModel : ReactiveObject , IRoutableViewModel
    {
        public string UrlPathSegment { get { return "AddressView"; } }
        public IScreen HostScreen { get; protected set; }

        private readonly IRepository<Address> _repository;
        private readonly ILogger<AddressViewModel> _logger;

        public AddressViewModel(
            IRepository<Address> repository,
            ILogger<AddressViewModel> logger,
            IScreen screen = null)
        {
            HostScreen = screen;

            _repository = repository;
            _logger = logger;


            CreateAddress = ReactiveCommand.Create(CreateAddressAsync());
        }

        private Action CreateAddressAsync()
        {
            return async delegate ()
            {
                await _repository.AddAsync(Address);
                await _repository.SaveChangesAsync();
            };
        }
        #region commands
        public ReactiveCommand<Unit, Unit> CreateAddress { get; }
        #endregion

        #region property
        public Address Address { get; set; }
        #endregion
    }
}