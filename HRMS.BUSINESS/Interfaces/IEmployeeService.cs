using HRMS.CORE;

namespace HRMS.BUSINESS;

public interface IEmployeeService
{
    Task<Employee> GetEmployeeById(int id);
    Task<EmployeeCardDTO> GetEmployeeCardAsync(int employeeId);
    Task<MyManagerCardDTO> GetMyManagerCardAsync(int employeeId);
    Task<List<EmployeeDTO>> GetAllEmployeesAsync(int employeeId);

}
