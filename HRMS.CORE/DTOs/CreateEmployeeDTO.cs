using System;

namespace HRMS.CORE.DTOs;

public class CreateEmployeeDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateTime HireDate { get; set; }
    public DateTime BirthDate { get; set; }
    public string PhoneNumber { get; set; }
    public int RemainingLeaveDays { get; set; }
    public int EducationLevelId { get; set; }
    public int GenderId { get; set; }
    public int JobId { get; set; }
    public int DepartmentId { get; set; }
    public int? ManagerEmployeeId { get; set; }
    public bool isActive { get; set; }
    public int? UserId { get; set; }
    public CreateAddressDTO createAddressDTO { get; set; }
    public SalaryDTO SalaryDTO { get; set; }
    public CreateResumeDTO createResumeDTO { get; set; }

}
