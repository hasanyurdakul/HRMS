using System;

namespace HRMS.CORE.DTOs;

public class CreateExpenseDTO
{
    public decimal Amount { get; set; }
    public DateTime ExpenseDate { get; set; }
    public string? Description { get; set; }
}
