using HRMS.CORE;
using Microsoft.EntityFrameworkCore;

namespace HRMS.DAL;

public class LeaveTypeRepository : Repository<LeaveType>, ILeaveTypeRepository
{
    public LeaveTypeRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<LeaveType> DeleteAsync(LeaveType leaveType)
    {
        _context.Entry(leaveType).State = EntityState.Deleted;
        await _context.SaveChangesAsync();
        return leaveType;
    }

    public async Task<LeaveType> UpdateAsync(LeaveType leaveType)
    {
        _context.LeaveTypes.Update(leaveType);
        await _context.SaveChangesAsync();
        return leaveType;
    }
}
