using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace HRMS.CORE;

public class Department
{
    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; }
    public int CompanyId { get; set; }
    [Key, ForeignKey("Employee")]
    public int EmployeeId { get; set; }

    // Navigation properties
    public Company Company { get; set; }
    public ICollection<Employee> Employees { get; set; }

}
