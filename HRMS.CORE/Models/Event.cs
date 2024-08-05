namespace HRMS.CORE;

public class Event
{
    public int EventId { get; set; }
    public string EventName { get; set; }
    public string EventDescription { get; set; }
    public DateTime EventStartDate { get; set; }
    public DateTime EventEndDate { get; set; }
    public int UserId { get; set; }
    public int CompanyId { get; set; }

    // Navigation properties
    public User User { get; set; }
    public Company Company { get; set; }
}
