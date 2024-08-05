using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.CORE;

public class User : IdentityUser<int>
{
    [Key, ForeignKey("Employee")]
    public int EmployeeId { get; set; }
    public int CompanyId { get; set; }
    public int EventId { get; set; }

    // Navigation properties
    public Employee Employee { get; set; }
    public Company Company { get; set; }
    public ICollection<Event> Events { get; set; }

}
