using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.CORE;

public class LeaveType
{
    public int Id { get; set; }
    public string Name { get; set; }
    //[ForeignKey("Leave")]

    // Navigation properties
    public ICollection<Leave> Leaves { get; set; }
}
