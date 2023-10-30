using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyProject.AppService.IService;
using MyProject.Models.Dtos;


namespace MyProject.Controllers;


public class EmployeeController : Controller
{
    private readonly IEmployeeService _service;

    public EmployeeController(IEmployeeService service)
    {
        _service = service;
    }
    
    [Authorize(Roles = "ADMIN")]
    public async Task<IActionResult> Index()
    {
        var list = await _service.GetAllEmployee();
        return View(list);
    }

    public async Task<IActionResult> EditEmployee(EmployeeDto employees)
    {
        var check = await _service.EditEmployee(employees);
        if (check)
        {
            return RedirectToAction("Index");
        }
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> DeleteEmployee(int id)
    {
        var check = await _service.DeleteEmployee(id);
        return RedirectToAction("Index");
    }
}