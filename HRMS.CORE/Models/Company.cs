using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.CORE;

public class Company
{
    public int CompanyId { get; set; }
    public string CompanyName { get; set; }
    public string CompanyEmail { get; set; }
    public string CompanyPhoneNumber { get; set; }
    public string CompanyLogoUrl { get; set; }
    [ForeignKey("Address")]
    public int AddressId { get; set; }
    [ForeignKey("EmployeeId")]
    public int EmployeeId { get; set; }
    [ForeignKey("DepartmentId")]
    public int DepartmentId { get; set; }
    [ForeignKey("EventId")]
    public int EventId { get; set; }
    [ForeignKey("ResumeId")]
    public int ResumeId { get; set; }
    [ForeignKey("UserId")]
    public int? UserId { get; set; }
    [ForeignKey("JobId")]
    public int JobId { get; set; }

    // Navigation properties
    public Address Address { get; set; }
    public ICollection<Employee> Employees { get; set; }
    public ICollection<Department> Departments { get; set; }
    public ICollection<Event> Events { get; set; }
    public ICollection<Resume> Resumes { get; set; }
    public ICollection<User>? Users { get; set; }
    public ICollection<Job> Jobs { get; set; }
}
