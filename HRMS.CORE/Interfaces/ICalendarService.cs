namespace HRMS.CORE;

public interface ICalendarService
{
    Task<List<CalendarEventDTO>> GetCompanyCalendarEventsAsync(int companyId);
}
