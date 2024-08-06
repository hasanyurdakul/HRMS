using HRMS.CORE;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.API;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<Role> _roleManager;

    public UserController(UserManager<User> userManager, RoleManager<Role> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    [HttpPost("createuser")]
    [Authorize(Roles = "Admin, CompanyOwner, CompanyManager")]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserDTO createUserDto)
    {
        var requestingUser = await _userManager.GetUserAsync(User);
        if (requestingUser == null)
        {
            return Unauthorized("Invalid user.");
        }

        string roleToAssign = null;

        if (User.IsInRole("Admin"))
        {
            roleToAssign = "CompanyOwner";
        }
        else if (User.IsInRole("CompanyOwner"))
        {
            roleToAssign = "CompanyManager";
        }
        else if (User.IsInRole("CompanyManager"))
        {
            roleToAssign = "CompanyUser";
        }
        else
        {
            return Forbid("You do not have permission to create users.");
        }

        var newUser = new User
        {
            UserName = createUserDto.Username,
            Email = createUserDto.Email,
            CompanyId = createUserDto.CompanyId,
            EmployeeId = createUserDto.EmployeeId
        };

        var result = await _userManager.CreateAsync(newUser, createUserDto.Password);
        if (!result.Succeeded)
        {
            return BadRequest(result.Errors);
        }

        var roleResult = await _userManager.AddToRoleAsync(newUser, roleToAssign);
        if (!roleResult.Succeeded)
        {
            await _userManager.DeleteAsync(newUser); // Rollback user creation if role assignment fails
            return BadRequest(roleResult.Errors);
        }

        return Ok(new { UserId = newUser.Id });
    }

}
