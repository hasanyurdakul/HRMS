using HRMS.CORE;
using HRMS.CORE.DTOs;

namespace HRMS.BUSINESS;

public interface IEventService
{
    Task<List<UpcomingEventsDTO>> GetUpcomingEventsAsync(int companyId);
    Task AddEventAsync(EventDTO eventDto);
    Task UpdateEventAsync(int eventId, EventDTO eventDto);
    Task DeleteEventAsync(int eventId);
}
