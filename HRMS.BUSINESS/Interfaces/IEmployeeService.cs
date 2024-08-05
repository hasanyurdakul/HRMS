using HRMS.CORE;

namespace HRMS.BUSINESS;

public interface IEmployeeService
{
    Task<Employee> GetEmployeeById(int id);
    Task<IList<Employee>> GetAllEmployees();
    Task<EmployeeCardDTO> GetEmployeeCardAsync(int employeeId);
}
