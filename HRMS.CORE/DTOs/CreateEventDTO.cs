using System;

namespace HRMS.CORE.DTOs;

public class CreateEventDTO
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }


}
