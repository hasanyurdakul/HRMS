using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.CORE;

public class Resume
{
    public int ResumeId { get; set; }
    public string ResumePath { get; set; }
    public int CompanyId { get; set; }
    [Key, ForeignKey("Employee")]
    public int EmployeeId { get; set; }

    // Navigation properties
    public Company Company { get; set; }
    public Employee Employee { get; set; }
}
