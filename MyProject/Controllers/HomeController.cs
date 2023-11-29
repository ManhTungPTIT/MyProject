using AmelaFood.SessionExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using MyProject.AppService.IService;
using MyProject.Constant;
using MyProject.Models.Model;




namespace MyProject.Controllers
{
    [Authorize]
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;
        private readonly IEmployeeService _employeeService;
        private readonly ICustomerService _customerService;
        private readonly IBillService _billService;
       

        public HomeController(ILogger<HomeController> logger, IProductService service, IEmployeeService employeeService, ICustomerService customerService, IBillService billService)
        {
            _logger = logger;
            _productService = service;
            _employeeService = employeeService;
            _customerService = customerService;
            _billService = billService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _productService.GetAllProduct();
            ViewBag.ListProduct = list;
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> AddToCart(int productId)
        {
             var product = await _productService.GetProductById(productId);
            var quantity = 1;

            List<Bill> orderProducts =
                HttpContext.Session.Get<List<Bill>>(Constants.OrderProducts) ?? new List<Bill>();

            if (product != null)
            {
                List<Product> addedProducts =
                    HttpContext.Session.Get<List<Product>>(Constants.Products) ?? new List<Product>();

                addedProducts.Add(product);
                var existingProduct = orderProducts.FirstOrDefault(op => op.ProductId == productId);
                if (existingProduct != null)
                {
                    existingProduct.Quantity ++;
                }
                else
                {
                    var orderProduct = new Bill
                    {
                        Quantity = quantity,
                        ProductId = product.Id,
                        TotalPPrice = product.Price,
                        Product = product,
                        CreateOn = DateTime.Now,
                    };

                    orderProducts.Add(orderProduct);
                }


                HttpContext.Session.Set(Constants.OrderProducts, orderProducts);
                HttpContext.Session.Set(Constants.Products, addedProducts);
            }

            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public async Task<List<Bill>>CartInfo()
        {
            var cartItems = HttpContext.Session.Get<List<Bill>>(Constants.OrderProducts);
            if (cartItems.Count != 0)
            {
                ViewData["OrderProduct"] = cartItems;
                return cartItems;
            }

            return cartItems;
        }

        [HttpPost]
        public async Task<bool> AddBill(string customerName, decimal total)
        {
            var name = User.Identity.Name;
            var check = await _productService.EmployeeAddBill(customerName, total, name);
            return true;
        }

        public async Task<IActionResult> ClearOrder(string name)
        {
            var order =
                HttpContext.Session.Get<List<Bill>>(Constants.OrderProducts);

            decimal total = 0;
            foreach (var bill in order)
            {
                total += bill.Quantity * bill.Product.Price;
            }

            var employee = new Employees
            {
                UserName = User.Identity.Name,
                Revenue = total,
            };
            await _employeeService.UpdateKpiEmployee(employee);

            var cus = new Customers
            {
                UserName = name,
                Phone = "0123456789",
                Address = "Ha Noi"
            };
            await _customerService.AddCustomer(cus);

            var cusId = await _customerService.GetIdByName(name);
            var empId = await _employeeService.GetIdByName(User.Identity.Name);
            foreach (var bill in order)
            {
                var data = new Bill
                {
                    CustomerId = cusId, 
                    EmployeeId = empId,
                    ProductId = bill.Product.Id,
                };

                await _billService.CreateBill(data);  
            }
            
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
        
    }
}