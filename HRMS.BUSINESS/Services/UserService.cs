using HRMS.CORE;
using Microsoft.AspNetCore.Identity;

namespace HRMS.BUSINESS;

public class UserService : IUserService
{

    private readonly IUserRepository _userRepository;
    private readonly IGenderRepository _genderRepository;
    private readonly ILeaveRepository _leaveRepository;
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly ISalaryRepository _salaryRepository;
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;


    public UserService(IUserRepository userRepository, IGenderRepository genderRepository, ILeaveRepository leaveRepository, ILeaveTypeRepository leaveTypeRepository, ISalaryRepository salaryRepository, UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _userRepository = userRepository;
        _genderRepository = genderRepository;
        _leaveRepository = leaveRepository;
        _leaveTypeRepository = leaveTypeRepository;
        _salaryRepository = salaryRepository;
        _userManager = userManager;
        _signInManager = signInManager;
    }


    public async Task<User> GetUserByUsername(string username)
    {
        return await _userRepository.GetByUserNameAsync(username);
    }

    public async Task<IList<User>> GetAllUsers()
    {
        return (IList<User>)await _userRepository.GetAllAsync();
    }

    public async Task<User> UpdateUser(User user)
    {
        return await _userRepository.UpdateAsync(user);
    }

    public async Task<User> GetUserById(int id)
    {
        return await _userRepository.GetByIdAsync(id);
    }

    public async Task<User> GetRelatedUser(int employeeId)
    {
        return await _userRepository.GetUserByEmployeeId(employeeId);
    }

    public async Task AddUserAsync(User user)
    {
        await _userRepository.AddAsync(user);
    }

    public async Task<User> Authenticate(string username, string password)
    {
        var user = await _userManager.FindByNameAsync(username);
        if (user != null && await _userManager.CheckPasswordAsync(user, password))
        {
            var result = await _signInManager.PasswordSignInAsync(username, password, false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return user;
            }
        }
        return null;
    }

    public async Task<IList<User>> GetUsersByCompanyId(int companyId)
    {
        return (IList<User>)await _userRepository.FindAsync(u => u.CompanyId == companyId);
    }
}
