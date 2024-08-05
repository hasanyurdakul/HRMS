using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.CORE;

public class Education
{
    public int EducationId { get; set; }
    public string EducationLevel { get; set; }
    [ForeignKey("Employee")]
    public int EmployeeId { get; set; }


    // Navigation properties
    public ICollection<Employee> Employees { get; set; }

}
