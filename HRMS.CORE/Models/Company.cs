namespace HRMS.CORE;

public class Company
{
    public int CompanyId { get; set; }
    public string CompanyName { get; set; }
    public string CompanyEmail { get; set; }
    public string CompanyPhoneNumber { get; set; }
    public string CompanyLogoUrl { get; set; }
    public int AddressId { get; set; }
    public int EmployeeId { get; set; }
    public int DepartmentId { get; set; }
    public int EventId { get; set; }
    public int ResumeId { get; set; }
    public int UserId { get; set; }

    // Navigation properties
    public Address Address { get; set; }
    public ICollection<Employee> Employees { get; set; }
    public ICollection<Department> Departments { get; set; }
    public ICollection<Event> Events { get; set; }
    public ICollection<Resume> Resumes { get; set; }
    public ICollection<User> Users { get; set; }
}
