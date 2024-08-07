using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.CORE;

public class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string? ImageUrl { get; set; }
    public DateTime HireDate { get; set; }
    public DateTime BirthDate { get; set; }
    public string PhoneNumber { get; set; }
    public int RemainingLeaveDays { get; set; }
    //[ForeignKey("Address")]
    //[ForeignKey("Company")]
    public int CompanyId { get; set; }
    //[ForeignKey("Education")]
    public int EducationLevelId { get; set; }
    //[ForeignKey("Gender")]
    public int GenderId { get; set; }
    //[ForeignKey("Job")]
    public int JobId { get; set; }
    //[ForeignKey("Department")]
    public int DepartmentId { get; set; }
    public int? ManagerEmployeeId { get; set; }
    //[ForeignKey("Salary")]
    public bool isActive { get; set; }
    //[ForeignKey("Resume")]
    //[ForeignKey("Expense")]
    //[ForeignKey("User")]
    public int? UserId { get; set; }
    //[ForeignKey("Leave")]

    // Navigation properties
    public EducationLevel EducationLevel { get; set; }
    public Gender Gender { get; set; }
    public Company Company { get; set; }
    public Job Job { get; set; }
    public Department Department { get; set; }
    public Address Address { get; set; }
    public Salary Salary { get; set; }
    public Resume Resume { get; set; }
    public ICollection<Expense>? Expenses { get; set; }
    public ICollection<Leave>? Leaves { get; set; }
    public User? User { get; set; }
}