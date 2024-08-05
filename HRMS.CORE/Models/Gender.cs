namespace HRMS.CORE;

public class Gender
{
    public int GenderId { get; set; }
    public string GenderName { get; set; }
    public int EmployeeId { get; set; }

    // Navigation properties
    public ICollection<Employee> Employees { get; set; }


}
