using HRMS.CORE;
using HRMS.DAL;
using Microsoft.EntityFrameworkCore;

namespace HRMS.BUSINESS;

public class LeaveService : ILeaveService
{
    private readonly AppDbContext _context;
    private readonly IEmployeeService _employeeService;

    public LeaveService(AppDbContext context, IEmployeeService employeeService)
    {
        _context = context;
        _employeeService = employeeService;
    }

    public async Task<LeaveCardDTO> GetLeaveCardAsync(int employeeId)
    {
        var employee = await _context.Employees.FindAsync(employeeId);

        if (employee == null)
        {
            return null;
        }

        var leaves = await _context.Leaves
            .Where(l => l.EmployeeId == employeeId)
            .Include(l => l.LeaveType)
            .Include(l => l.RequestStatus)
            .ToListAsync();

        var leaveDetails = leaves.Select(l => new LeaveDetailDTO
        {
            LeaveType = l.LeaveType.Name,
            StartDate = l.StartDate,
            EndDate = l.EndDate,
            RequestStatus = l.RequestStatus.Name
        }).ToList();

        var leaveCard = new LeaveCardDTO
        {
            RemainingLeaveDays = employee.RemainingLeaveDays,
            Leaves = leaveDetails
        };

        return leaveCard;
    }
}
