using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.CORE;

public class Salary
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    //[ForeignKey("Employee")]
    public int EmployeeId { get; set; }

    // Navigation properties
    public Employee Employee { get; set; }

}
