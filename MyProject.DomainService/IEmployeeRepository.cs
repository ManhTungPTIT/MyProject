using MyProject.Models.Dtos;

namespace MyProject.DomainService;

public interface IEmployeeRepository
{
    Task<List<EmployeeDto>> GetAllEmployeeAsync();
    Task<bool> EditEmployeeAsync(EmployeeDto employeeDto);
    Task<bool> DeleteEmployeeAsync(int id);
    Task<bool> UpdateCompetence(KPIsDto kpi);
}