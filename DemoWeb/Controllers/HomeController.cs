using DemoWeb.Codes;
using DemoWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DemoWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMembership _membership;
        public HomeController([FromKeyedServices("Setup 2")] IMembership membership)
        {
            _membership = membership;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateAccount()
        {
            var model = new AccountModel();
            return View(model);
        }
        [HttpPost]
        public IActionResult CreateAccount(AccountModel model)
        {

            _membership.CreateUserAccount(model.UserName, model.Password);
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
