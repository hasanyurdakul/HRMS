using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.CORE;

public class Gender
{
    public int Id { get; set; }
    public string Name { get; set; }

    // Navigation properties
    public ICollection<Employee> Employees { get; set; }


}
