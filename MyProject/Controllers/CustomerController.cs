using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyProject.AppService.IService;
using MyProject.Models.Model;

namespace MyProject.Controllers
{
   
   
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
            bool check = await _customerService.AddCustomer(customers);
            return View("Index");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int customerId)
        {
            bool check = await _customerService.DeleteCustomer(customerId);
            return View("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Customers customers)
        {
            bool check = await _customerService.EditCustomer(customers);
            return View("Index");
        }
    }
}
