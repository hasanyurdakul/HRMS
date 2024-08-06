using HRMS.CORE;
using HRMS.DAL;
using Microsoft.EntityFrameworkCore;

namespace HRMS.BUSINESS;

public class EmployeeService : IEmployeeService
{

    private readonly IEmployeeRepository _employeeRepository;
    private readonly IUserRepository _userRepository;
    private readonly IGenderRepository _genderRepository;
    private readonly ILeaveRepository _leaveRepository;
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly ISalaryRepository _salaryRepository;
    private readonly AppDbContext _context;


    public EmployeeService(AppDbContext context, IEmployeeRepository employeeRepository, IUserRepository userRepository, IGenderRepository genderRepository, ILeaveRepository leaveRepository, ILeaveTypeRepository leaveTypeRepository, ISalaryRepository salaryRepository)
    {
        _employeeRepository = employeeRepository;
        _userRepository = userRepository;
        _genderRepository = genderRepository;
        _leaveRepository = leaveRepository;
        _leaveTypeRepository = leaveTypeRepository;
        _salaryRepository = salaryRepository;
        _context = context;

    }

    public async Task<Employee> GetEmployeeById(int id)
    {
        return await _employeeRepository.GetByIdAsync(id);
    }

    public async Task<IList<Employee>> GetAllEmployees()
    {
        return (IList<Employee>)await _employeeRepository.GetAllAsync();
    }

    public async Task<EmployeeCardDTO> GetEmployeeCardAsync(int employeeId)
    {
        var employee = await _context.Employees
                       .Include(e => e.Job)
                       .Include(e => e.Department)
                       .FirstOrDefaultAsync(e => e.EmployeeId == employeeId);

        if (employee == null)
        {
            return null;
        }

        var manager = await _context.Employees.FindAsync(employee.ManagerId);

        var employeeCard = new EmployeeCardDTO
        {
            EmployeeFirstName = employee.FirstName,
            EmployeeLastName = employee.LastName,
            JobTitle = employee.Job.JobTitle,
            DepartmentName = employee.Department.DepartmentName,
            ManagerName = manager != null ? $"{manager.FirstName} {manager.LastName}" : null,
            HireDate = employee.HireDate,
            ImageUrl = employee.ImageUrl
        };

        return employeeCard;

    }

    public async Task<MyManagerCardDTO> GetMyManagerCardAsync(int employeeId)
    {
        var employee = await _context.Employees.FindAsync(employeeId);
        if (employee == null || employee.ManagerId == 0)
        {
            return null;
        }

        var manager = await _context.Employees
            .Include(m => m.Job)
            .Include(m => m.Department)
            .FirstOrDefaultAsync(m => m.EmployeeId == employee.ManagerId);

        if (manager == null)
        {
            return null;
        }

        var managerDTO = new MyManagerCardDTO
        {
            ManagerFirstName = manager.FirstName,
            ManagerLastName = manager.LastName,
            JobTitle = manager.Job?.JobTitle,
            DepartmentName = manager.Department?.DepartmentName
        };

        return managerDTO;
    }
}
