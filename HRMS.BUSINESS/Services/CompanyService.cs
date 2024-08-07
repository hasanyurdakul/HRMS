using HRMS.CORE;
using HRMS.DAL;
using Microsoft.EntityFrameworkCore;

namespace HRMS.BUSINESS;

public class CompanyService : ICompanyService
{
    private readonly AppDbContext _context;

    public CompanyService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<List<UpcomingBirthdaysDTO>> GetUpcomingBirthdaysAsync(int companyId)
    {
        var today = DateTime.Today;
        var employees = await _context.Employees
        .Include(e => e.Department)
            .Where(e => e.Id == companyId)
            .OrderBy(e => EF.Functions.DateDiffDay(today, e.BirthDate))
            .Select(e => new UpcomingBirthdaysDTO
            {
                EmployeeFirstName = e.FirstName,
                EmployeeLastName = e.LastName,
                BirthDate = e.BirthDate,
                EmployeeImageUrl = e.ImageUrl
            })
            .ToListAsync();

        return employees;
    }
}
