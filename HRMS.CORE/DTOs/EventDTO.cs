using System;

namespace HRMS.CORE.DTOs;

public class EventDTO
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int CompanyId { get; set; }
    public int UserId { get; set; }
}
