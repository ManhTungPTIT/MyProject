using Microsoft.EntityFrameworkCore;
using MyProject.DomainService;
using MyProject.Infrastructure.ApplicationContext;
using MyProject.Models.Model;

namespace MyProject.Infrastructure.Repository;

public class BillRepository : Reposotory<Bill>, IBillRepository
{
    public BillRepository(ApplicationDBContext Context) : base(Context)
    {
    }

    public async Task<bool> CreateBillAsync(Bill bill)
    {
        Context.Set<Bill>().Add(bill);
        await Context.SaveChangesAsync();
        return true;
    }

    public async Task<List<Bill>> GetAllAsync()
    {
        var list = await Context.Set<Bill>()
            .Select(b => new Bill
            {
                Customers = b.Customers,
                Employees = b.Employees,
            }).ToListAsync();

        return list;
    }

    public async Task<List<int>> GetProductId(int employeeId)
    {
        var list = await Context.Set<Bill>()
            .Where(b => b.EmployeeId == employeeId)
            .Select(b => b.ProductId)
            .ToListAsync();

        return list;
    }
}