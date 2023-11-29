using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyProject.AppService.IService;

namespace MyProject.Controllers
{
    [Authorize]
    [Authorize(Roles = "ADMIN")]
    public class EvaluteController : Controller
    {
        
        private readonly IEmployeeService _employeeService; 
        public EvaluteController( IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public async Task<IActionResult> Index()
        {
            var list = await _employeeService.GetAllEmployee();
            ViewBag.List = list;
            return View();
        }
    }
}
