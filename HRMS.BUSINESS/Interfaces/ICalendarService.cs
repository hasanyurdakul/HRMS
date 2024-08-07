using System;
using HRMS.CORE;

namespace HRMS.BUSINESS.Interfaces;


public interface ICalendarService
{
    Task<List<CalendarEventDTO>> GetCompanyCalendarEventsAsync(int companyId);
}