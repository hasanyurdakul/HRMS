using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.CORE;

public class LeaveType
{
    public int LeaveTypeId { get; set; }
    public string LeaveTypeName { get; set; }
    [ForeignKey("Leave")]
    public int LeaveId { get; set; }

    // Navigation properties
    public ICollection<Leave> Leaves { get; set; }
}
