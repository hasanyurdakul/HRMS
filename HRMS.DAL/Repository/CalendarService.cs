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
                        .Where(e => e.CompanyId == companyId)
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
                Title = e.EventName,
                Start = e.EventStartDate,
                End = e.EventEndDate,
                Type = "Event",
                Description = e.EventDescription
            }).ToListAsync();

        var nationalHolidays = await _context.NationalHolidays
            .Select(h => new CalendarEventDTO
            {
                Title = h.NationalHolidayName,
                Start = h.NationalHolidayStartDate,
                End = h.NationalHolidayEndDate,
                Type = "NationalHoliday",
                Description = h.NationalHolidayName
            }).ToListAsync();

        return companyEmployees.Concat(companyEvents).Concat(nationalHolidays).ToList();
    }
}
