namespace HRMS.CORE;

public interface IEmployeeRepository : IRepository<Employee>
{
    Task<Employee> UpdateAsync(Employee employee);
    Task<Employee> DeleteAsync(Employee employee);

}
