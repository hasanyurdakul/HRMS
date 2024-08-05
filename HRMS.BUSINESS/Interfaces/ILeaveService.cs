using HRMS.CORE;

namespace HRMS.BUSINESS;

public interface ILeaveService
{
    Task<LeaveCardDTO> GetLeaveCardAsync(int employeeId);
}
