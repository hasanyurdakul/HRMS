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

    public async Task<List<EmployeeDTO>> GetAllEmployeesAsync(int employeeId)
    {
        var employee = await _context.Employees.FindAsync(employeeId);
        if (employee == null)
        {
            return null;
        }

        var companyEmployees = await _context.Employees
            .Where(e => e.CompanyId == employee.CompanyId)
            .Include(e => e.Job)
            .Include(e => e.Department)
            .Select(e => new EmployeeDTO
            {
                EmployeeImageUrl = e.ImageUrl,
                EmployeeFirstName = e.FirstName,
                EmployeeLastName = e.LastName,
                EmployeeEmail = e.Email,
                EmployeePhoneNumber = e.PhoneNumber,
                JobTitle = e.Job.Title,
                DepartmentName = e.Department.Name
            })
            .ToListAsync();

        return companyEmployees;
    }

    public async Task<Employee> GetEmployeeById(int id)
    {
        return await _employeeRepository.GetByIdAsync(id);
    }

    public async Task<EmployeeCardDTO> GetEmployeeCardAsync(int employeeId)
    {
        var employee = await _context.Employees
                       .Include(e => e.Job)
                       .Include(e => e.Department)
                       .FirstOrDefaultAsync(e => e.Id == employeeId);

        if (employee == null)
        {
            return null;
        }

        var manager = await _context.Employees.FindAsync(employee.ManagerEmployeeId);

        var employeeCard = new EmployeeCardDTO
        {
            EmployeeFirstName = employee.FirstName,
            EmployeeLastName = employee.LastName,
            EmployeeEmail = employee.Email,
            EmployeePhoneNumber = employee.PhoneNumber,
            JobTitle = employee.Job.Title,
            DepartmentName = employee.Department.Name,
            ManagerName = manager != null ? $"{manager.FirstName} {manager.LastName}" : null,
            HireDate = employee.HireDate,
            ImageUrl = employee.ImageUrl,
            GenderId = employee.GenderId
        };

        return employeeCard;

    }

    public async Task<MyManagerCardDTO> GetMyManagerCardAsync(int employeeId)
    {
        var employee = await _context.Employees.FindAsync(employeeId);
        if (employee == null || employee.ManagerEmployeeId == 0)
        {
            return null;
        }

        var manager = await _context.Employees
            .Include(m => m.Job)
            .Include(m => m.Department)
            .FirstOrDefaultAsync(m => m.Id == employee.ManagerEmployeeId);

        if (manager == null)
        {
            return null;
        }

        var managerDTO = new MyManagerCardDTO
        {
            ManagerFirstName = manager.FirstName,
            ManagerLastName = manager.LastName,
            ManagerImageUrl = manager.ImageUrl,
            ManagerEmail = manager.Email,
            ManagerPhoneNumber = manager.PhoneNumber,
            JobTitle = manager.Job?.Title,
            DepartmentName = manager.Department?.Name
        };

        return managerDTO;
    }
}
