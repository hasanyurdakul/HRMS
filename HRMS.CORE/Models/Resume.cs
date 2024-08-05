using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HRMS.CORE;

public class Resume
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ResumeId { get; set; }
    public string ResumePath { get; set; }
    [ForeignKey("Company")]
    public int CompanyId { get; set; }
    [ForeignKey("Employee")]
    public int EmployeeId { get; set; }

    // Navigation properties
    public Company Company { get; set; }
    public Employee Employee { get; set; }
}
