using System.Security.Claims;
using HRMS.BUSINESS;
using HRMS.CORE;
using HRMS.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRMS.API.Controllers
{
    [Authorize(Roles = ("CompanyOwner,CompanyManager,CompanyUser"))]
    [Route("api/[controller]")]
    [ApiController]
    public class BirthdayController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly AppDbContext _context;
        public BirthdayController(ICompanyService companyService, AppDbContext context)
        {
            _companyService = companyService;
            _context = context;
        }

        [HttpGet("GetUpcomingBirthdays")]
        public async Task<ActionResult<UpcomingBirthdaysDTO>> GetUpcomingBirthdays()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _context.Users.Include(u => u.Employee).FirstOrDefaultAsync(u => u.Id == int.Parse(userId));

            if (user == null || user.CompanyId == null)
            {
                return BadRequest("User or CompanyId not found.");
            }
            var upcomingBirthdayList = await _companyService.GetUpcomingBirthdaysAsync(user.CompanyId);
            return Ok(upcomingBirthdayList);
        }
    }
}
