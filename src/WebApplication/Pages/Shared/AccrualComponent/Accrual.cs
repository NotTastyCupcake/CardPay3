using Metcom.CardPay3.Infrastructure.Identity;
using Metcom.CardPay3.WebApplication.Interfaces;
using Metcom.CardPay3.WebApplication.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.WebApplication.Pages.Shared.AccrualComponent
{
    public class Accrual : ViewComponent
    {
        private readonly IAccrualViewModelService _accrualService;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public Accrual(IAccrualViewModelService accrualService,
            SignInManager<ApplicationUser> signInManager)
        {
            _accrualService = accrualService;
            _signInManager = signInManager;
        }

        public async Task<IViewComponentResult> InvokeAsync(string userName)
        {
            var vm = new AccrualComponentViewModel();
            vm.AccrualDay = (await GetAccrualViewModelAsync()).AccrualDay;
            return View(vm);
        }

        private async Task<AccrualViewModel> GetAccrualViewModelAsync()
        {
            if (_signInManager.IsSignedIn(HttpContext.User))
            {
                return await _accrualService.GetOrCreateAsyncAccrualForUser(User.Identity.Name);
            }
            string anonymousId = GetAccrualIdFromCookie();
            if (anonymousId == null) return new AccrualViewModel();
            return await _accrualService.GetOrCreateAsyncAccrualForUser(anonymousId);
        }

        private string GetAccrualIdFromCookie()
        {
            if (Request.Cookies.ContainsKey(Constants.ACCRUAL_COOKIENAME))
            {
                return Request.Cookies[Constants.ACCRUAL_COOKIENAME];
            }
            return null;
        }
    }
}
