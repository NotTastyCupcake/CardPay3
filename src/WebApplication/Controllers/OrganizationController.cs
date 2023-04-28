using Metcom.CardPay3.ApplicationCore.Entities;
using Metcom.CardPay3.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Metcom.CardPay3.WebApplication.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Authorize]
    [Route("[controller]/[action]")]
    public class OrganizationController : Controller
    {
        private readonly IRepository<Organization> _repository;

        public OrganizationController(IRepository<Organization> repository)
        {
            _repository = repository;
        }

        [HttpGet()]
        public IActionResult Index()
        {
            return View();
        }
    }
}
