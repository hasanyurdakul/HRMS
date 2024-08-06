using Microsoft.AspNetCore.Identity;

namespace HRMS.CORE;

public class Role : IdentityRole<int>
{
    public Role() : base() { }

    public Role(string roleName) : base(roleName)
    {
    }
}
