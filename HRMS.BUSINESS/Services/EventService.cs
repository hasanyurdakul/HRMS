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
            .Where(e => e.CompanyId == companyId && e.StartDate >= today)
            .OrderBy(e => e.StartDate)
            .Select(e => new UpcomingEventsDTO
            {
                EventName = e.Name,
                EventStartDate = e.StartDate,
                EventEndDate = e.EndDate,
                EventDescription = e.Description,
                EventCreatorName = _context.Users
                    .Include(u => u.Employee)
                    .Where(u => u.Id == e.UserId)
                    .Select(u => $"{u.Employee.FirstName} {u.Employee.LastName}")
                    .FirstOrDefault()
            }).ToListAsync();

        return events;
    }
}
