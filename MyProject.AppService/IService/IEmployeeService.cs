using MyProject.Models.Dtos;
using MyProject.Models.Model;

namespace MyProject.AppService.IService;

public interface IEmployeeService
{
    Task<List<EmployeeDto>> GetAllEmployee();
    Task<bool> EditEmployee(EmployeeDto employeeDto);
    Task<bool> DeleteEmployee(int id);
    Task<bool> UpdateKpiEmployee(Employees employees);
    Task<Employees> GetEmployeeByName(string name);
    Task<int> GetIdByName(string name);
    Task<List<EmployeeDto>> GetEmployeeByProduct(int productId);
}