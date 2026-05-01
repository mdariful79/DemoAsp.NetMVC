using DemoWeb.Codes;
using DemoWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Diagnostics;

namespace DemoWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMembership _membership;
        private readonly ILogger<HomeController> _logger;
        public HomeController([FromKeyedServices("Setup 2")] IMembership membership, ILogger<HomeController> logger)
        {
            _membership = membership;
            _logger = logger;
        }
        public IActionResult Index()
        {
            UnitOfWork uow = new UnitOfWork();
            uow.Products.Add(new Product());
            //uow.Order.Add(new Order());
            uow.Save();

            Log.Debug("Iam in Home Page");
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
