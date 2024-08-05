using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.CORE;

public class Expense
{
    public int ExpenseId { get; set; }
    [ForeignKey("Employee")]
    public int EmployeeId { get; set; }
    public int Amount { get; set; }
    public DateTime ExpenseDate { get; set; }
    public string ExpenseDescription { get; set; }
    public DateTime RequestedDate { get; set; }
    [ForeignKey("RequestStatus")]
    public int RequestStatusId { get; set; }
    public int ApprovedById { get; set; }

    // Navigation properties
    public Employee Employee { get; set; }
    public RequestStatus RequestStatus { get; set; }
}

