using Microsoft.AspNetCore.Mvc;
using Mvcdemo.Models;

namespace Mvcdemo.Controllers
{
    public class VirusController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create2(Virus virus)
        {
            return View("Create2",virus);
        }
    }
}
