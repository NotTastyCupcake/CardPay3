using Metcom.CardPay3.ApplicationCore.Entities;
using Metcom.CardPay3.ApplicationCore.Interfaces;
using Metcom.CardPay3.ApplicationCore.Specifications;
using Metcom.CardPay3.Infrastructure.Identity;
using Metcom.CardPay3.WebApplication.Interfaces;
using Metcom.CardPay3.WebApplication.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Metcom.CardPay3.WebApplication.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Authorize] // Controllers that mainly require Authorization still use Controller/View; other pages use Pages
    [Route("[controller]/[action]")]
    public class EmployeController : Controller
    {
        private readonly ILogger<EmployeController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmployerViewModelService _service;

        public EmployeController(ILogger<EmployeController> logger,
            UserManager<ApplicationUser> userManager,
            IEmployerViewModelService service)
        {
            
            _logger = logger;
            _userManager = userManager;
            _service = service;
        }

        [HttpGet]
        // GET: EmployController
        public async Task<IActionResult> Index(int? organizationFilterApplied, int? page)
        {
            var itemsPage = 10;
            var employeModel = await _service.GetEmployers(page ?? 0, itemsPage, organizationFilterApplied ?? 1);
            return View(employeModel);
        }

        [HttpGet]
        // GET: EmployController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var vm = await _service.GetEmploye(id);
            return PartialView("_Details_Modal", vm);
        }

        // GET: EmployController/Create
        public async Task<IActionResult> Create()
        {
            var vm = await _service.GetGenders();
            ViewBag.Genders = vm;

            return View();
        }

        // POST: EmployController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            return View();
        }

        // POST: EmployController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            return View();
        }

        // POST: EmployController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
