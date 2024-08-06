using HRMS.CORE;

namespace HRMS.BUSINESS;

public interface ITokenService
{
    string CreateToken(int? employeeId, int? companyId, string roleName);

}
