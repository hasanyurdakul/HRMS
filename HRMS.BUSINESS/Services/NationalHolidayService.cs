using HRMS.CORE;
using HRMS.DAL;
using Microsoft.EntityFrameworkCore;

namespace HRMS.BUSINESS;

public class NationalHolidayService : INationalHolidayService
{
    private readonly AppDbContext _context;

    public NationalHolidayService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<UpcomingNationalHolidayDTO>> GetUpcomingNationalHolidaysAsync()
    {
        var today = DateTime.Today;
        var holidays = await _context.NationalHolidays
            .Where(h => h.NationalHolidayStartDate >= today)
            .OrderBy(h => h.NationalHolidayStartDate)
            .Take(5)
            .Select(h => new UpcomingNationalHolidayDTO
            {
                NationalHolidayName = h.NationalHolidayName,
                NationalHolidayStartDate = h.NationalHolidayStartDate,
                NationalHolidayEndDate = h.NationalHolidayEndDate
            })
            .ToListAsync();

        return holidays;
    }
}
