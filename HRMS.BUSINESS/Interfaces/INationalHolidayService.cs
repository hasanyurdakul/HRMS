using HRMS.CORE;

namespace HRMS.BUSINESS;

public interface INationalHolidayService
{
    Task<List<UpcomingNationalHolidayDTO>> GetUpcomingNationalHolidaysAsync();
}
