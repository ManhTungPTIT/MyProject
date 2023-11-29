using Microsoft.EntityFrameworkCore;
using MyProject.DomainService;
using MyProject.Infrastructure.ApplicationContext;
using MyProject.Models.Dtos;
using MyProject.Models.Model;

namespace MyProject.Infrastructure.Repository;

public class EmployeeRepository : Reposotory<Employees>, IEmployeeRepository
{
    public EmployeeRepository(ApplicationDBContext Context) : base(Context)
    {
    }

    public async Task<List<EmployeeDto>> GetAllEmployeeAsync()
    {
        var list = await Context.Set<Employees>()
            .Where(e => e.DeleteOn == null)
            .Select(e => new EmployeeDto
            {
                Id = e.Id,
                UserName = e.UserName,
                DayOfMonth = e.DayOfMonth,
                Revenue = e.Revenue,
            }).ToListAsync();
        return list;
    }

    public async Task<bool> EditEmployeeAsync(EmployeeDto employeeDto)
    {
        var employee = await Context.Set<Employees>()
            .Where(e => e.Id == employeeDto.Id)
            .FirstOrDefaultAsync();

        employee.UserName = employeeDto.UserName;
        employee.UpdateOn = DateTime.Now;

        await Context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteEmployeeAsync(int id)
    {
        var employee = await Context.Set<Employees>().FirstOrDefaultAsync(e => e.Id == id);
        
        employee.DeleteOn = DateTime.Now;
        await Context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateKpiEmployeeAsync(Employees employees)
    {
        var data = await Context.Set<Employees>()
            .Where(p => p.UserName == employees.UserName)
            .FirstOrDefaultAsync();

        if (data != null)
        {
            data.Revenue += employees.Revenue;
            data.UpdateOn = DateTime.Now;
            data.DayOfMonth += 1;
            data.Kpis = data.Revenue / data.DayOfMonth;

            Context.Update(data);
            await Context.SaveChangesAsync();
            return true;
        }

        return false;
    }

    public async Task<Employees> GetEmployeeByName(string name)
    {
        var employee = await Context.Set<Employees>()
            .FirstOrDefaultAsync(p => p.UserName == name);
        return employee;
    }

    public async Task<int> GetIdByNameAsync(string name)
    {
        var id = await Context.Set<Employees>()
            .Where(e => e.UserName == name)
            .Select(e => e.Id)
            .FirstOrDefaultAsync();

        return id;
    }

    public async Task<List<EmployeeDto>> GetEmployeeByProduct(int productId)
    {
        var list = await Context.Set<Employees>()
            .Where(em => em.Bills.Any(pc => pc.ProductId == productId))
            .Select(em => new EmployeeDto()
            {
                Id = em.Id,
                UserName = em.UserName,
                Revenue = em.Revenue,
                ProductDtos = em.Bills.Select(pc => new ProductDto
                {
                    ProductName = pc.Product.ProductName,
                    Price = pc.Product.Price,
                    Avatar = pc.Product.Avatar,
                }).ToList()
            }).ToListAsync();

        return list;
    }
    
}