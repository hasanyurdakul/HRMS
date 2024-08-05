﻿using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.CORE;

public class Leave
{
    public int LeaveId { get; set; }
    [ForeignKey("Employee")]
    public int EmployeeId { get; set; }
    [ForeignKey("LeaveType")]
    public int LeaveTypeId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime RequestedDate { get; set; }
    [ForeignKey("RequestStatus")]
    public int RequestStatusId { get; set; }
    public int ApprovedById { get; set; }

    // Navigation properties
    public Employee Employee { get; set; }
    public LeaveType LeaveType { get; set; }
    public RequestStatus RequestStatus { get; set; }
}
