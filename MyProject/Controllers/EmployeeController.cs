using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyProject.Controllers;


public class EmployeeController : Controller
{
    
    public IActionResult Index(string? money)
    {
        var name = User.Identity.Name;
        
        return View();
    }
}