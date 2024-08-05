namespace HRMS.CORE;

public interface IGenderRepository : IRepository<Gender>
{
    Task<Gender> UpdateAsync(Gender gender);
    Task<Gender> DeleteAsync(Gender gender);
}
