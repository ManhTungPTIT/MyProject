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
                Competence = e.Competence,
            }).ToListAsync();
        return list;
    }

    public async Task<bool> EditEmployeeAsync(EmployeeDto employeeDto)
    {
        var employee = await Context.Set<Employees>()
            .Where(e => e.Id == employeeDto.Id)
            .FirstOrDefaultAsync();

        employee.UserName = employeeDto.UserName;
        employee.Competence = employeeDto.Competence;
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

    public async Task<bool> UpdateCompetence(KPIsDto kpi)
    {
        var user = await Context.Set<Employees>().FirstOrDefaultAsync(u => u.Id == kpi.EmployeeId);

        if (kpi.Kpis > 1000000)
        {
            user.Competence = "Good";
        }
        else
        {
            user.Competence = "Fail";
        }

        await Context.SaveChangesAsync();
        return true;
    }

   
}