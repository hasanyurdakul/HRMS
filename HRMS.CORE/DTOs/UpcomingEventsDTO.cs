﻿namespace HRMS.CORE;

public class UpcomingEventsDTO
{
    public string EventName { get; set; }
    public DateTime EventStartDate { get; set; }
    public DateTime EventEndDate { get; set; }
    public string EventDescription { get; set; }
    public string EventCreatorName { get; set; }
}