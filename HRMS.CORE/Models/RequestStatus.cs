using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.CORE;

public class RequestStatus
{
    public int Id { get; set; }
    public string Name { get; set; }



    // Navigation properties
    public ICollection<Expense> Expenses { get; set; }
    public ICollection<Leave> Leaves { get; set; }
}
