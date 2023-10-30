using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyProject.AppService.IService;
using MyProject.Models.Model;


namespace MyProject.Controllers
{
    
    [Authorize(Roles = "ADMIN")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            this._customerService = customerService;   
        }
        public async Task<IActionResult> Index()
        {
            var list = await _customerService.GetAll();
            ViewData["ListCustomer"] = list;
            
            return View();
        }

        
        public async Task<IActionResult> AddCustomer(Customers customers)
        {
            await _customerService.AddCustomer(customers);
            return View("Index");
        }

        
        public async Task<IActionResult> Delete(int customerId)
        {
            await _customerService.DeleteCustomer(customerId);
            return RedirectToAction("Index");
        }

        
        public async Task<IActionResult> Edit(Customers customers)
        {
            await _customerService.EditCustomer(customers);
            return RedirectToAction("Index");
        }
    }
}
