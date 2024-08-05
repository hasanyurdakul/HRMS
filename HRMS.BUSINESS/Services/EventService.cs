using HRMS.CORE;
using HRMS.DAL;
using Microsoft.EntityFrameworkCore;

namespace HRMS.BUSINESS;

public class EventService : IEventService
{
    private readonly AppDbContext _context;

    public EventService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<UpcomingEventsDTO>> GetUpcomingEventsAsync(int companyId)
    {
        var today = DateTime.Today;
        var events = await _context.Events
            .Where(e => e.CompanyId == companyId && e.EventStartDate >= today)
            .OrderBy(e => e.EventStartDate)
            .Select(e => new UpcomingEventsDTO
            {
                EventName = e.EventName,
                EventStartDate = e.EventStartDate,
                EventEndDate = e.EventEndDate,
                EventDescription = e.EventDescription,
                EventCreatorName = _context.Employees
                    .Where(emp => emp.EmployeeId == e.User.EmployeeId)
                    .Select(emp => $"{emp.FirstName} {emp.LastName}")
                    .FirstOrDefault()
            }).ToListAsync();

        return events;
    }
}
