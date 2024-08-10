using System;

namespace HRMS.CORE.DTOs;

public class CreateLeaveDTO
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int LeaveTypeId { get; set; }
    public string? Description { get; set; }
}
