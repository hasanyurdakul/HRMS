namespace HRMS.CORE;

public interface ISalaryRepository : IRepository<Salary>
{
    Task<Salary> UpdateAsync(Salary salary);
    Task<Salary> DeleteAsync(Salary salary);
}
