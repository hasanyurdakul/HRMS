using System.Security.Claims;
using HRMS.BUSINESS;
using HRMS.CORE;
using HRMS.CORE.DTOs;
using HRMS.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRMS.API.Controllers
{
    [Authorize(Roles = "CompanyAdmin,CompanyManager")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // [HttpGet]
        // public async Task<IActionResult> GetAllUsers()
        // {
        //     var currentUser = await _userManager.GetUserAsync(User);
        //     var users = await _context.Users.Where(u => u.CompanyId == currentUser.CompanyId).ToListAsync();

        //     var GetUserDTOs = users.Select(u => new GetUserDTO
        //     {
        //         Id = u.Id,
        //         UserName = u.UserName,
        //         Email = u.Email,
        //         PhoneNumber = u.PhoneNumber,
        //         CompanyId = u.CompanyId
        //     }).ToList();

        //     return Ok(GetUserDTOs);
        // }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetUserDTO>>> GetUsersByCompany()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userService.GetUserById(int.Parse(userId));

            if (user == null || user.CompanyId == null)
            {
                return BadRequest("User or CompanyId not found.");
            }

            var users = await _userService.GetUsersByCompanyId(user.CompanyId.Value);
            var getUserDTOs = users.Select(u => new GetUserDTO
            {
                Id = u.Id,
                UserName = u.UserName,
                Email = u.Email,
                CompanyId = u.CompanyId
            }).ToList();

            return Ok(getUserDTOs);
        }
    }
}
