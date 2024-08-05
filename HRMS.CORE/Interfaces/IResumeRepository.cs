namespace HRMS.CORE;

public interface IResumeRepository : IRepository<Resume>
{
    Task<Resume> UpdateAsync(Resume resume);
    Task<Resume> DeleteAsync(Resume resume);

}
