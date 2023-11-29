using Microsoft.EntityFrameworkCore;
using MyProject.DomainService;
using MyProject.Infrastructure.ApplicationContext;
using MyProject.Models.Dtos;
using MyProject.Models.Model;

namespace MyProject.Infrastructure.Repository;

public class ProductRepository : Reposotory<Product>, IProductRepository
{
    public ProductRepository(ApplicationDBContext Context) : base(Context)
    {
    }

    public async Task<Product> GetProductByIdAsync(int id)
    {
        var product = await Context.Set<Product>()
            .Where(p => p.Id == id)
            .Select(p => new Product
            {
                Id = p.Id,
                ProductName = p.ProductName,
                Avatar = p.Avatar,
                Price = p.Price,
            }).FirstOrDefaultAsync();

        return product;
    }

    public async Task<List<Product>> GetAllProductAsync()
    {
        var list = await Context.Set<Product>()
            .Select(p => new Product
            {
                Id = p.Id,
                ProductName = p.ProductName,
                Price = p.Price,
                Avatar = p.Avatar,
            }).ToListAsync();

        return list;
    }

    
}