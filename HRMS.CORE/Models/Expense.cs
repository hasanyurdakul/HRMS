namespace HRMS.CORE;

public class Expense
{
    public int ExpenseId { get; set; }
    public int EmployeeId { get; set; }
    public int Amount { get; set; }
    public DateTime ExpenseDate { get; set; }
    public string ExpenseDescription { get; set; }
    public DateTime RequestedDate { get; set; }
    public int RequestStatusId { get; set; }
    public int ApprovedById { get; set; }

    // Navigation properties
    public Employee Employee { get; set; }
    public RequestStatus RequestStatus { get; set; }
}

