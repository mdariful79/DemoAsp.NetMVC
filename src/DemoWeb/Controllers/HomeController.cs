using Cortex.Mediator;
using DemoApplication.Contracts;
using DemoApplication.Features.Products.Command;
using DemoDomain.Entities;
using DemoInfrastructure.Data;
using DemoWeb.Codes;
using DemoWeb.Models;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Diagnostics;

namespace DemoWeb.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, IMediator mediator, IMapper mapper)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            
           

            Log.Debug("I am in Home Controller");
            return View();
        }
        public IActionResult CreateProduct()
        {
            var model = new CreateProductModel();
            return View(model);
        }
        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult CreateProduct(CreateProductModel model)
        {
            if(ModelState.IsValid)
            {
                var command = _mapper.Map<ProductAddCommand>(model);
                var result = _mediator.SendCommandAsync(command).Result;
            }
            return View(model);
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
