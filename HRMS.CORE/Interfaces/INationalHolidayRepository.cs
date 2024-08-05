namespace HRMS.CORE;

public interface INationalHolidayRepository : IRepository<NationalHoliday>
{
    Task<NationalHoliday> UpdateAsync(NationalHoliday nationalHoliday);
    Task<NationalHoliday> DeleteAsync(NationalHoliday nationalHoliday);
}
