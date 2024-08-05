namespace HRMS.CORE;

public class RequestStatus
{
    public int RequestStatusId { get; set; }
    public string RequestStatusName { get; set; }
    public int ExpenseId { get; set; }

    // Navigation properties
    public ICollection<Expense> Expenses { get; set; }
}
