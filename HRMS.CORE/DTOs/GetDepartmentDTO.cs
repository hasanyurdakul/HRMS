using System;

namespace HRMS.CORE.DTOs;

public class GetDepartmentDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CompanyId { get; set; }
}
