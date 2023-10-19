using MyProject.Models.Dtos;

namespace MyProject.AppService.IService;

public interface IEmployeeService
{
    Task<List<EmployeeDto>> GetAllEmployee();
    Task<bool> EditEmployee(EmployeeDto employeeDto);
    Task<bool> DeleteEmployee(int id);
    Task<bool> UpdateCompetence(KPIsDto kpi);
}