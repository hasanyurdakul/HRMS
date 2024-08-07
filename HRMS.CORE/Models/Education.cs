using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.CORE;

public class EducationLevel
{
    public int Id { get; set; }
    public string Name { get; set; }
    //[ForeignKey("Employee")]


    // Navigation properties
    public ICollection<Employee> Employees { get; set; }

}
