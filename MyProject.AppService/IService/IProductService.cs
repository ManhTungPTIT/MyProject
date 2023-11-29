using MyProject.Models.Dtos;
using MyProject.Models.Model;

namespace MyProject.AppService.IService;

public interface IProductService
{
    Task<Product> GetProductById(int id);
    Task<List<Product>> GetAllProduct();
    Task<bool> EmployeeAddBill(string customerName, decimal total, string name);
}