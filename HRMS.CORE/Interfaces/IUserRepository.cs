namespace HRMS.CORE;

public interface IUserRepository : IRepository<User>
{
    Task<User> UpdateAsync(User user);
    Task<User> DeleteAsync(User user);
    Task<User> GetByUserNameAsync(string userName);
    Task<User> GetUserByEmployeeId(int employeeId);
}
