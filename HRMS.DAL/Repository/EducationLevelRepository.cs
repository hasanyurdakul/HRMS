using HRMS.CORE;
using Microsoft.EntityFrameworkCore;

namespace HRMS.DAL;

public class EducationLevelRepository : Repository<EducationLevel>, IEducationLevelRepository
{
    public EducationLevelRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<EducationLevel> DeleteAsync(EducationLevel educationLevel)
    {
        _context.Entry(educationLevel).State = EntityState.Deleted;
        await _context.SaveChangesAsync();
        return educationLevel;
    }

    public async Task<EducationLevel> UpdateAsync(EducationLevel educationLevel)
    {
        _context.EducationLevels.Update(educationLevel);
        await _context.SaveChangesAsync();
        return educationLevel;
    }
}
