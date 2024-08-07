using HRMS.CORE;

namespace HRMS.BUSINESS;

public interface ITokenService
{
    Task<string> GenerateToken(User user);
}

