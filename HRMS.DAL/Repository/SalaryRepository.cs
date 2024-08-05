using HRMS.CORE;
using Microsoft.EntityFrameworkCore;

namespace HRMS.DAL;

public class SalaryRepository : Repository<Salary>, ISalaryRepository
{
    public SalaryRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Salary> DeleteAsync(Salary salary)
    {
        _context.Entry(salary).State = EntityState.Deleted;
        await _context.SaveChangesAsync();
        return salary;
    }

    public async Task<Salary> UpdateAsync(Salary salary)
    {
        _context.Salaries.Update(salary);
        await _context.SaveChangesAsync();
        return salary;
    }
}
