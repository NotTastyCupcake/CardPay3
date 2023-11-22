using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Metcom.CardPay3.WebApplication.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Authorize] // Controllers that mainly require Authorization still use Controller/View; other pages use Pages
    [Route("[controller]/[action]")]
    public class AccrualController : Controller
    {
        // GET: AccrualController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AccrualController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AccrualController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AccrualController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: AccrualController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AccrualController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: AccrualController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AccrualController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
