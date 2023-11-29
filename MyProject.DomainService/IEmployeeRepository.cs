using MyProject.Models.Dtos;
using MyProject.Models.Model;

namespace MyProject.DomainService;

public interface IEmployeeRepository
{
    Task<List<EmployeeDto>> GetAllEmployeeAsync();
    Task<bool> EditEmployeeAsync(EmployeeDto employeeDto);
    Task<bool> DeleteEmployeeAsync(int id);
    Task<bool> UpdateKpiEmployeeAsync(Employees employees);
    Task<Employees> GetEmployeeByName(string name);
    Task<int> GetIdByNameAsync(string name);
    Task<List<EmployeeDto>> GetEmployeeByProduct(int productId);
}