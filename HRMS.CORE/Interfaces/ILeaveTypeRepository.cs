namespace HRMS.CORE;

public interface ILeaveTypeRepository : IRepository<LeaveType>
{
    Task<LeaveType> UpdateAsync(LeaveType leaveType);
    Task<LeaveType> DeleteAsync(LeaveType leaveType);
}
