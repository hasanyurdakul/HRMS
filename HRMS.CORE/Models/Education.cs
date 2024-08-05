namespace HRMS.CORE;

public class Education
{
    public int EducationId { get; set; }
    public string EducationLevel { get; set; }
    public int EmployeeId { get; set; }


    // Navigation properties
    public ICollection<Employee> Employees { get; set; }

}
