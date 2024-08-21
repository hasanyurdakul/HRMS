using HRMS.CORE;

namespace HRMS.BUSINESS;

public interface IUserService
{
    Task<User> GetUserByUsername(string username);
    Task<IList<User>> GetAllUsers();
    Task<User> UpdateUser(User user);
    Task<User> GetUserById(int id);
    Task<User> GetRelatedUser(int employeeId);
    Task AddUserAsync(User user);
    Task<User> Authenticate(string username, string password);
    Task<IList<User>> GetUsersByCompanyId(int companyId);

}
