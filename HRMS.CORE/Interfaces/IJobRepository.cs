namespace HRMS.CORE;

public interface IJobRepository : IRepository<Job>
{
    Task<Job> UpdateAsync(Job job);
    Task<Job> DeleteAsync(Job job);

}