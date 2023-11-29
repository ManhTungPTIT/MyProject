using MyProject.AppService.IService;
using MyProject.DomainService;
using MyProject.Models.Dtos;
using MyProject.Models.Model;

namespace MyProject.AppService.Service;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;
    private readonly ICustomerService _customerService;
    private readonly IEmployeeService _employeeService;

    public ProductService(IProductRepository repository, ICustomerService customerService, IEmployeeService employeeService)
    {
        _repository = repository;
        _customerService = customerService;
        _employeeService = employeeService;
    }
    public async Task<Product> GetProductById(int id)
    {
        return await _repository.GetProductByIdAsync(id);
    }

    public async Task<List<Product>> GetAllProduct()
    {
        return await _repository.GetAllProductAsync();
    }

    public async Task<bool> EmployeeAddBill(string customerName,decimal total , string name)
    {
        var customer = new Customers
        {
            UserName = customerName,
            Phone = "0123456789",
            Address = "Viet Nam",
            CreateOn = DateTime.Now,
        };
        var checkCus = await _customerService.AddCustomer(customer);

        var employee = await _employeeService.GetEmployeeByName(name);
        employee.Revenue = total;

        var checkEmployee = await _employeeService.UpdateKpiEmployee(employee);
        if (checkEmployee == true && checkCus == true)
        {
            return true;
        }

        return false;
    }
}