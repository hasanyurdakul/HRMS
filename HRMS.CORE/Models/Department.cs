using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace HRMS.CORE;

public class Department
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; }
    [ForeignKey("Company")]
    public int CompanyId { get; set; }
    [ForeignKey("Employee")]
    public int EmployeeId { get; set; }

    // Navigation properties
    public Company Company { get; set; }
    public ICollection<Employee> Employees { get; set; }

}
