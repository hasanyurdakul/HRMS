using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.CORE;

public class User : IdentityUser<int>
{
    [ForeignKey("Employee")]
    public int? EmployeeId { get; set; }
    [ForeignKey("Company")]
    public int? CompanyId { get; set; }
    [NotMapped]
    public int? EventId { get; set; }

    // Navigation properties
    public Employee? Employee { get; set; }
    public Company? Company { get; set; }
    public ICollection<Event>? Events { get; set; }

}
