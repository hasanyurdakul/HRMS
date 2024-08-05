using HRMS.CORE;

namespace HRMS.BUSINESS;

public class UserService
{

    private readonly IUserRepository _userRepository;
    private readonly IGenderRepository _genderRepository;
    private readonly ILeaveRepository _leaveRepository;
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly ISalaryRepository _salaryRepository;

    public UserService(IUserRepository userRepository, IGenderRepository genderRepository, ILeaveRepository leaveRepository, ILeaveTypeRepository leaveTypeRepository, ISalaryRepository salaryRepository)
    {
        _userRepository = userRepository;
        _genderRepository = genderRepository;
        _leaveRepository = leaveRepository;
        _leaveTypeRepository = leaveTypeRepository;
        _salaryRepository = salaryRepository;
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

}
