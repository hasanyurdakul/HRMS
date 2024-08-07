namespace HRMS.CORE;

public interface IEducationLevelRepository : IRepository<EducationLevel>
{
    Task<EducationLevel> UpdateAsync(EducationLevel education);
    Task<EducationLevel> DeleteAsync(EducationLevel education);
}
