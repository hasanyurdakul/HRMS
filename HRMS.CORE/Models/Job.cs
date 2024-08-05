using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.CORE;

public class Job
{
    public int JobId { get; set; }
    public string JobTitle { get; set; }
    [ForeignKey("Company")]
    public int CompanyId { get; set; }
    [ForeignKey("Employee")]
    public int EmployeeId { get; set; }

    // Navigation properties
    public Company Company { get; set; }
    public ICollection<Employee> Employees { get; set; }
}
