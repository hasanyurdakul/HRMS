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
    public int CompanyId { get; set; }
    public int EducationLevelId { get; set; }
    public int GenderId { get; set; }
    public int JobId { get; set; }
    public int DepartmentId { get; set; }
    public int? ManagerEmployeeId { get; set; }
    public bool isActive { get; set; }
    public int? UserId { get; set; }

    // Navigation properties
    // OK
    public EducationLevel? EducationLevel { get; set; }
    // OK
    public Gender? Gender { get; set; }
    // OK
    public Company? Company { get; set; }
    // OK 
    public Job? Job { get; set; }
    // OK
    public Department? Department { get; set; }
    // OK
    public Address? Address { get; set; }
    // OK
    public Salary? Salary { get; set; }
    // OK
    public Resume? Resume { get; set; }
    // OK
    public ICollection<Expense>? Expenses { get; set; }
    // OK
    public ICollection<Leave>? Leaves { get; set; }
    // OK
    public User? User { get; set; }
}
