using System;

namespace HRMS.CORE.DTOs;

public class GetExpenseDTO
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public DateTime ExpenseDate { get; set; }
    public DateTime RequestedDate { get; set; }
    public string? Description { get; set; }
    public int RequestStatusId { get; set; }
    public int EmployeeId { get; set; }

}
