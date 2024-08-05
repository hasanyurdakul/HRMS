namespace HRMS.CORE;

public class LeaveCardDTO
{
    public int RemainingLeaveDays { get; set; }
    public List<LeaveDetailDTO> Leaves { get; set; }
}
