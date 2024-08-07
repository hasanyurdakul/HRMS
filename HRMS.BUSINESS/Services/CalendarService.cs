using HRMS.BUSINESS.Interfaces;
using HRMS.CORE;
using Microsoft.EntityFrameworkCore;

namespace HRMS.DAL;

public class CalendarService : ICalendarService
{
    private readonly AppDbContext _context;

    public CalendarService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<CalendarEventDTO>> GetCompanyCalendarEventsAsync(int companyId)
    {
        var companyEmployees = await _context.Employees
                        .Include(e => e.Department)
                        .Where(e => e.Department.CompanyId == companyId)
                        .Select(e => new CalendarEventDTO
                        {
                            Title = $"{e.FirstName} {e.LastName}'s Birthday",
                            Start = e.BirthDate,
                            End = e.BirthDate,
                            Type = "Birthday",
                            Description = $"{e.FirstName} {e.LastName}'s Birthday"
                        }).ToListAsync();

        var companyEvents = await _context.Events
            .Where(e => e.CompanyId == companyId)
            .Select(e => new CalendarEventDTO
            {
                Title = e.Name,
                Start = e.StartDate,
                End = e.EndDate,
                Type = "Event",
                Description = e.Description
            }).ToListAsync();

        var nationalHolidays = await _context.NationalHolidays
            .Select(h => new CalendarEventDTO
            {
                Title = h.Name,
                Start = h.StartDate,
                End = h.EndDate,
                Type = "NationalHoliday",
                Description = h.Name
            }).ToListAsync();

        return companyEmployees.Concat(companyEvents).Concat(nationalHolidays).ToList();
    }
}
