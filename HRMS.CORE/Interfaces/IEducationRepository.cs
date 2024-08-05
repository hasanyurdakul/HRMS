namespace HRMS.CORE;

public interface IEducationRepository : IRepository<Education>
{
    Task<Education> UpdateAsync(Education education);
    Task<Education> DeleteAsync(Education education);
}
