namespace HRMS.CORE;

public interface IRoleRepository : IRepository<Role>
{
    Task<Role> UpdateAsync(Role role);
    Task<Role> DeleteAsync(Role role);
}
