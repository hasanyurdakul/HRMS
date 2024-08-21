using System;

namespace HRMS.CORE.DTOs;

public class GetUserDTO
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public int? CompanyId { get; set; }
}
