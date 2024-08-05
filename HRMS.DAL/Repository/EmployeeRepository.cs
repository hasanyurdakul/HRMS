using HRMS.CORE;
using Microsoft.EntityFrameworkCore;

namespace HRMS.DAL;

public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Employee> DeleteAsync(Employee employee)
    {
        _context.Entry(employee).State = EntityState.Deleted;
        await _context.SaveChangesAsync();
        return employee;
    }

    public async Task<Employee> UpdateAsync(Employee employee)
    {
        _context.Employees.Update(employee);
        await _context.SaveChangesAsync();
        return employee;
    }
}
