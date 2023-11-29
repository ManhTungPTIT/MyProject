using MyProject.Models.Dtos;
using MyProject.Models.Model;

namespace MyProject.DomainService;

public interface IProductRepository
{
    Task<Product> GetProductByIdAsync(int id);
    Task<List<Product>> GetAllProductAsync();
}