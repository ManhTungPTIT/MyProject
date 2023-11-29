using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyProject.AppService.IService;
using MyProject.DomainService;
using MyProject.Models.Dtos;
using MyProject.Models.Model;


namespace MyProject.Controllers;


public class EmployeeController : Controller
{
    private readonly IEmployeeService _service;
    private readonly IBillService _billService;
    private readonly IProductService _productService;

    public EmployeeController(IEmployeeService service, IBillService billService, IProductService productService)
    {
        _service = service;
        _billService = billService;
        _productService = productService;
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

    public async Task<List<Product>> DetailEmployee(string name)
    {
        var list = new List<Product>();
        var emId = await _service.GetIdByName(name);

        var listProductId = await _billService.GetProductId(emId);
        foreach (var productId in listProductId)
        {
            var product = await _productService.GetProductById(productId);
            list.Add(product);
        }
        return list;
    }
}