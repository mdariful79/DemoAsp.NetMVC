using DemoWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoWeb.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            var model = new TestHome 
            { 
                Name = "Ariful Islam", 
                Email = "ariful@gmail.com",
                PartialModel = new PartialModel { Address = "Ctg"}
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
