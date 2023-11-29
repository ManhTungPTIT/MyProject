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
        private readonly IBillService _billService;

        public CustomerController(ICustomerService customerService, IBillService billService)
        {
            this._customerService = customerService;
            _billService = billService;
        }
        public async Task<IActionResult> Index()
        {
            var listBill = await _billService.GetAll();
            var listCus = await _customerService.GetAll();
            ViewData["ListCustomer"] = listBill;
            ViewBag.ListCus = listCus;
            
            return View();
        }

        
        public async Task<IActionResult> AddCustomer(Customers customers)
        {
            await _customerService.AddCustomer(customers);
            var empId = await _customerService.GetIdByName(customers.UserName);
            var data = new Bill
            {
                CustomerId = 1, 
                EmployeeId = empId,
            };
            await _billService.CreateBill(data);
            return RedirectToAction("Index");
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
