namespace HRMS.CORE;

public class Employee
{
    public int EmployeeId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string? ImageUrl { get; set; }
    public DateTime HireDate { get; set; }
    public DateTime BirthDate { get; set; }
    public string PhoneNumber { get; set; }
    public int RemainingLeaveDays { get; set; }
    public int EducationId { get; set; }
    public int GenderId { get; set; }
    public int CompanyId { get; set; }
    public int JobId { get; set; }
    public int DepartmentId { get; set; }
    public int ManagerId { get; set; }
    public int AddressId { get; set; }
    public int SalaryId { get; set; }
    public bool isActive { get; set; }
    public int ResumeId { get; set; }
    public int ExpenseId { get; set; }
    public int UserId { get; set; }

    // Navigation properties
    public Education Education { get; set; }
    public Gender Gender { get; set; }
    public Company Company { get; set; }
    public Job Job { get; set; }
    public Department Department { get; set; }
    public Address Address { get; set; }
    public Salary Salary { get; set; }
    public Resume Resume { get; set; }
    public ICollection<Expense> Expenses { get; set; }
    public User User { get; set; }
}