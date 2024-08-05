using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.CORE;

public class Salary
{
    public int SalaryId { get; set; }
    public int Amount { get; set; }
    [Key, ForeignKey("Employee")]
    public int EmployeeId { get; set; }

    // Navigation properties
    public Employee Employee { get; set; }

}
