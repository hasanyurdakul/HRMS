using HRMS.CORE;
using Microsoft.EntityFrameworkCore;

namespace HRMS.DAL;

public class RequestStatusRepository : Repository<RequestStatus>, IRequestStatusRepository
{
    public RequestStatusRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<RequestStatus> DeleteAsync(RequestStatus requestStatus)
    {
        _context.Entry(requestStatus).State = EntityState.Deleted;
        await _context.SaveChangesAsync();
        return requestStatus;
    }

    public async Task<RequestStatus> UpdateAsync(RequestStatus requestStatus)
    {
        _context.RequestStatuses.Update(requestStatus);
        await _context.SaveChangesAsync();
        return requestStatus;
    }
}
