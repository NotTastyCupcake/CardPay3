using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Metcom.CardPay3.ApplicationCore.Interfaces;
using Metcom.CardPay3.Infrastructure.Identity;
using Metcom.CardPay3.WebApplication.Interfaces;
using Metcom.CardPay3.WebApplication.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Metcom.CardPay3.WebApplication.Pages.Accrual
{
    public class IndexModel : PageModel
    {
        private readonly IAccrualService _accrualService;
        private readonly IAccrualViewModelService _accrualViewModelService;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private string _username = null;

        public IndexModel(IAccrualService accrualService,
            IAccrualViewModelService accrualViewModelService, 
            SignInManager<ApplicationUser> signInManager)
        {
            _accrualService = accrualService;
            _accrualViewModelService = accrualViewModelService;
            _signInManager = signInManager;
        }

        public AccrualViewModel AccrualModel { get; set; } = new AccrualViewModel();

        public async Task OnGet()
        {
            await SetAccrualModelAsync();
        }

        public async Task<IActionResult> OnPost(AccrualItemViewModel accrualDetails)
        {
            if (accrualDetails?.Id == null)
            {
                return RedirectToPage("/Index");
            }
            await SetAccrualModelAsync();

            await _accrualService.AddItemToAccrual(AccrualModel.OrganizationId,
                accrualDetails.EmployerId,
                accrualDetails.Date, 
                accrualDetails.Amount,
                AccrualModel.IdAccrualType,
                AccrualModel.IdOperationType);

            await SetAccrualModelAsync();

            return RedirectToPage();
        }

        public async Task OnPostUpdate(Dictionary<string, decimal> items)
        {
            await SetAccrualModelAsync();

            await _accrualService.SetAmounts(AccrualModel.Id, items);

            await SetAccrualModelAsync();
        }

        private async Task SetAccrualModelAsync()
        {
            if (_signInManager.IsSignedIn(HttpContext.User))
            {
                AccrualModel = await _accrualViewModelService.GetOrCreateAsyncAccrualForUser(User.Identity.Name); 
            }
            else
            {
                GetOrSetAccrualCookieAndUserName();
                AccrualModel = await _accrualViewModelService.GetOrCreateAsyncAccrualForUser(_username);
            }
        }
        private void GetOrSetAccrualCookieAndUserName()
        {
            if (Request.Cookies.ContainsKey(Constants.ACCRUAL_COOKIENAME))
            {
                _username = Request.Cookies[Constants.ACCRUAL_COOKIENAME];
            }
            if (_username != null) return;

            _username = Guid.NewGuid().ToString();
            var cookieOptions = new CookieOptions { IsEssential = true };
            cookieOptions.Expires = DateTime.Today.AddYears(10);
            Response.Cookies.Append(Constants.ACCRUAL_COOKIENAME, _username, cookieOptions);
        }
    }
}
