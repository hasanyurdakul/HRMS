namespace HRMS.CORE;

public interface ICompanyRepository : IRepository<Company>
{
    Task<Company> UpdateAsync(Company company);
    Task<Company> DeleteAsync(Company company);

}
