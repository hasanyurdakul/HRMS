using HRMS.CORE;
using HRMS.CORE.DTOs;
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
                EventId = e.Id,
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

    public async Task AddEventAsync(EventDTO eventDto)
    {
        var newEvent = new Event
        {
            Name = eventDto.Name,
            Description = eventDto.Description,
            StartDate = eventDto.StartDate,
            EndDate = eventDto.EndDate,
            CompanyId = eventDto.CompanyId,
            UserId = eventDto.UserId
        };

        _context.Events.Add(newEvent);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateEventAsync(int eventId, EventDTO eventDto)
    {
        var existingEvent = await _context.Events.FindAsync(eventId);
        if (existingEvent != null)
        {
            existingEvent.Name = eventDto.Name;
            existingEvent.Description = eventDto.Description;
            existingEvent.StartDate = eventDto.StartDate;
            existingEvent.EndDate = eventDto.EndDate;

            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteEventAsync(int eventId)
    {
        var eventToDelete = await _context.Events.FindAsync(eventId);
        if (eventToDelete != null)
        {
            _context.Events.Remove(eventToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
