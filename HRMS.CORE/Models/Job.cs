using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.CORE;

public class Job
{
    public int Id { get; set; }
    public string Title { get; set; }
    //[ForeignKey("Company")]
    public int CompanyId { get; set; }
    //[ForeignKey("Employee")]

    // Navigation properties
    public Company Company { get; set; }
    public ICollection<Employee> Employees { get; set; }
}
