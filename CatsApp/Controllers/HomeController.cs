using CatsApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CatsApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;      

        public HomeController(ILogger<HomeController> logger)          // wstrzykiwanie zale¿noœci logger do HomeController
        {
            _logger = logger;                                      // przypisanie logger do pola _logger
        }

        public IActionResult Index()         
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]                
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });         // przekazanie do widoku ErrorViewModel
        }
    }
}
