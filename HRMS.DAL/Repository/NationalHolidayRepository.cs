using HRMS.CORE;
using Microsoft.EntityFrameworkCore;

namespace HRMS.DAL;

public class NationalHolidayRepository : Repository<NationalHoliday>, INationalHolidayRepository
{
    public NationalHolidayRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<NationalHoliday> DeleteAsync(NationalHoliday nationalHoliday)
    {
        _context.Entry(nationalHoliday).State = EntityState.Deleted;
        await _context.SaveChangesAsync();
        return nationalHoliday;
    }

    public async Task<NationalHoliday> UpdateAsync(NationalHoliday nationalHoliday)
    {
        _context.NationalHolidays.Update(nationalHoliday);
        await _context.SaveChangesAsync();
        return nationalHoliday;
    }
}
