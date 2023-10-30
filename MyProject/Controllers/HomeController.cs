using Microsoft.AspNetCore.Mvc;
using MyProject.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;

namespace MyProject.Controllers
{
    [Authorize]
    [Authorize(Roles = "USER")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        

        
    }
}