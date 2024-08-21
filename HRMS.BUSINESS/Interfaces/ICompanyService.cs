using HRMS.CORE;

namespace HRMS.BUSINESS;

public interface ICompanyService
{
    Task<List<UpcomingBirthdaysDTO>> GetUpcomingBirthdaysAsync(int? companyId);
}
