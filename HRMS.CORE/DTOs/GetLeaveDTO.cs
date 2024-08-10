using System;

namespace HRMS.CORE.DTOs;

public class GetLeaveDTO
{
    public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime RequestedDate { get; set; }
    public int ApprovedById { get; set; }
    public int EmployeeId { get; set; }
    public int LeaveTypeId { get; set; }
    public int RequestStatusId { get; set; }
}
