namespace HRMS.CORE;

public interface ICompanyRepository : IRepository<Company>
{
    Task UpdateAsync(Company company);
    Task DeleteAsync(Company company);

}
