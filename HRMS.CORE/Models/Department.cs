using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace HRMS.CORE;

public class Department
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CompanyId { get; set; }
    public bool isActive { get; set; }


    // Navigation properties
    public Company Company { get; set; }
    public ICollection<Employee> Employees { get; set; }

}
