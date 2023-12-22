using Metcom.CardPay3.ApplicationCore.Interfaces.ServicesInterfaces;
using Metcom.CardPay3.ApplicationCore.Interfaces.ServicesInterfaces.Builder;
using Metcom.CardPay3.Infrastructure.Identity;
using Metcom.CardPay3.WebApplication.Interfaces;
using Metcom.CardPay3.WebApplication.ViewModels.Employes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
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
        private readonly IEmployerViewModelService _viewModelservice;
        private readonly IEmployeeBuilder _service;

        public EmployeController(ILogger<EmployeController> logger,
            UserManager<ApplicationUser> userManager,
            IEmployerViewModelService viewModelService,
            IEmployeeBuilder service)
        {

            _logger = logger;
            _userManager = userManager;
            _viewModelservice = viewModelService;
            _service = service;
        }

        [HttpGet]
        // GET: EmployController
        public async Task<IActionResult> Index(int? organizationFilterApplied, int? page)
        {
            var itemsPage = 10;
            var employeModel = await _viewModelservice.GetEmployers(page ?? 0, itemsPage, organizationFilterApplied ?? 1);
            return View(employeModel);
        }

        [HttpGet]
        // GET: EmployController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var vm = await _viewModelservice.GetEmploye(id);
            return PartialView("_Details_Modal", vm);
        }
        [HttpGet]
        // GET: EmployController/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Genders = await _viewModelservice.GetGenders();
            ViewBag.DocumentTypes = await _viewModelservice.GetDocumentTypes();

            return PartialView("_Create_Model");
        }

        // POST: EmployController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeCreateViewModel employerModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.FindByNameAsync(User.Identity.Name);

                    //var builder = await _service.SetGender(employerModel.IdGender);
                    //await builder.SetDocument(employerModel.IdType,
                    //   employerModel.DataIssued, employerModel.IssuedBy, employerModel.SubdivisionCode);
                    //await builder.SetOrganization(user.IdOrganization);

                    //var employer = _service.GetEmploye(employerModel.LastName, employerModel.FirstName, employerModel.MiddleName,
                    //   employerModel.PhoneNumber, employerModel.JobPhoneNumber, employerModel.Position, employerModel.DepartmentNum);

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Genders = await _viewModelservice.GetGenders();
                    ViewBag.DocumentTypes = await _viewModelservice.GetDocumentTypes();

                    return View("_Create_Model", employerModel);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Genders = await _viewModelservice.GetGenders();
                ViewBag.DocumentTypes = await _viewModelservice.GetDocumentTypes();
                _logger.LogError(exception: ex, "Ошибка!");
                return View("_Create_Model");
            }
        }

        //// GET: EmployController/Edit/5
        //public async Task<IActionResult> Edit(int id)
        //{
        //    return View();
        //}

        //// POST: EmployController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: EmployController/Delete/5
        //public async Task<IActionResult> Delete(int id)
        //{
        //    return View();
        //}

        //// POST: EmployController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
