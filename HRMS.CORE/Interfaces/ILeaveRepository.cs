namespace HRMS.CORE;

public interface ILeaveRepository : IRepository<Leave>
{
    Task<Leave> UpdateAsync(Leave leave);
    Task<Leave> DeleteAsync(Leave leave);

}
