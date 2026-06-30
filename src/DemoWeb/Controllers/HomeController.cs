using Cortex.Mediator;
using DemoApplication.Contracts;
using DemoApplication.Features.Products.Command;
using DemoDomain.Entities;
using DemoInfrastructure.Data;
using DemoWeb.Codes;
using DemoWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Diagnostics;

namespace DemoWeb.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly IMediator _mediator;

        public HomeController(ILogger<HomeController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }
        public IActionResult Index()
        {
            var command = new ProductAddCommand
            {
                Id = Guid.NewGuid(),
                Name = "Sample Product",
                Price = 99.99
            };
           var result = _mediator.SendCommandAsync(command).Result;

            Log.Debug("I am in Home Controller");
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

            //_membership.CreateUserAccount(model.UserName, model.Password);
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
