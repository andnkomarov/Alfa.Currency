using System.Diagnostics;
using Alfa.Curremcy.Managers.Abstract;
using Alfa.Curremcy.Models;
using Microsoft.AspNetCore.Mvc;

namespace Alfa.Curremcy.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICurrencyManager _currencyManager;

        public HomeController(ICurrencyManager currencyManager)
        {
            _currencyManager = currencyManager;
        }

        public IActionResult Index()
        {
            var model = _currencyManager.GetCurrencyListViewModel();

            return View(model);
        }

        [HttpPost]
        public IActionResult GetSelected(string selectedCurrencyId)
        {
            var value = _currencyManager.GetCurrencyValueById(selectedCurrencyId);

            return Json(new
            {
                Success = "true",
                Data = new 
                {
                    Value = value
                }
            });
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
