using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.CORE;

public class RequestStatus
{
    public int RequestStatusId { get; set; }
    public string RequestStatusName { get; set; }

    [ForeignKey("Expense")]
    public int? ExpenseId { get; set; }

    [ForeignKey("Leave")]
    public int? LeaveId { get; set; }

    // Navigation properties
    public ICollection<Expense> Expenses { get; set; }
    public ICollection<Leave> Leaves { get; set; }
}
