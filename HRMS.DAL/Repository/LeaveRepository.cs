using HRMS.CORE;
using Microsoft.EntityFrameworkCore;

namespace HRMS.DAL;

public class LeaveRepository : Repository<Leave>, ILeaveRepository
{
    public LeaveRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Leave> DeleteAsync(Leave leave)
    {
        _context.Entry(leave).State = EntityState.Deleted;
        await _context.SaveChangesAsync();
        return leave;
    }

    public async Task<Leave> UpdateAsync(Leave leave)
    {
        _context.Leaves.Update(leave);
        await _context.SaveChangesAsync();
        return leave;
    }
}
