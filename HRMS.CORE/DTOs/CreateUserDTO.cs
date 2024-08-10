namespace HRMS.CORE;

public class CreateUserDTO
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string? Password { get; set; }
    public int? CompanyId { get; set; }
    public int? EmployeeId { get; set; }
}
