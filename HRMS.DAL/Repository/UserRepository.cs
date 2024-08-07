using HRMS.CORE;
using Microsoft.EntityFrameworkCore;

namespace HRMS.DAL;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<User> DeleteAsync(User user)
    {
        _context.Entry(user).State = EntityState.Deleted;
        await _context.SaveChangesAsync();
        return user;
    }

    public Task<User> GetByUserNameAsync(string userName)
    {
        return _context.Users.FirstOrDefaultAsync(u => u.UserName == userName);
    }

    public Task<User> GetUserByEmployeeId(int employeeId)
    {
        return _context.Users.Include(e => e.Employee).FirstOrDefaultAsync(u => u.Employee.Id == employeeId);

    }

    public async Task<User> UpdateAsync(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
        return user;
    }
}
