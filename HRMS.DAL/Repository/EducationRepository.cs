using HRMS.CORE;
using Microsoft.EntityFrameworkCore;

namespace HRMS.DAL;

public class EducationRepository : Repository<Education>, IEducationRepository
{
    public EducationRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Education> DeleteAsync(Education education)
    {
        _context.Entry(education).State = EntityState.Deleted;
        await _context.SaveChangesAsync();
        return education;
    }

    public async Task<Education> UpdateAsync(Education education)
    {
        _context.Educations.Update(education);
        await _context.SaveChangesAsync();
        return education;
    }
}
