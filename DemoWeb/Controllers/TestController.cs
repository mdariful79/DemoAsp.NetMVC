using DemoWeb.Codes;
using DemoWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoWeb.Controllers
{
    public class TestController : Controller
    {
        private readonly IMembership _membership;
        public TestController([FromKeyedServices("Setup 1")] IMembership membership)
        {
            _membership = membership;
        }
        public IActionResult Index()
        {
            var model = new TestHome 
            { 
                Name = "Ariful Islam", 
                Email = "ariful@gmail.com",
                PartialModel = new PartialModel { Address = "Ctg", PhoneNumber="1234567890"}
            };
            return View(model);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Index (TestHome model)
        {
            var email = model.Email;
            var name = model.Name;
            
            return View(model);
        }
    }
}
