using HRMS.CORE;

namespace HRMS.BUSINESS;

public interface IEventService
{
    Task<List<UpcomingEventsDTO>> GetUpcomingEventsAsync(int companyId);

}
