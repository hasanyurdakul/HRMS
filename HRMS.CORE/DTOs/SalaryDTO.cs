using System;

namespace HRMS.CORE.DTOs;

public class SalaryDTO
{
    public int? SalaryId { get; set; }
    public int EmployeeId { get; set; }
    public decimal? Amount { get; set; }
}
