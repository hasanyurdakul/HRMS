using System.Security.Claims;
using HRMS.BUSINESS;
using HRMS.CORE;
using HRMS.CORE.DTOs;
using HRMS.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveController : ControllerBase
    {
        private readonly ILeaveRepository _leaveRepository;
        private readonly IUserRepository _userRepository;
        private readonly AppDbContext _context;
        private readonly ILeaveService _leaveService;

        public LeaveController(ILeaveRepository leaveRepository, IUserRepository userRepository, AppDbContext context, ILeaveService leaveService)
        {
            _leaveRepository = leaveRepository;
            _userRepository = userRepository;
            _context = context;
            _leaveService = leaveService;
        }

        // GET: api/Leave
        [Authorize(Roles = "CompanyManager")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetLeaveDTO>>> GetLeaves()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userRepository.GetByIdAsync(int.Parse(userId));

            if (user == null || user.CompanyId == null)
            {
                return BadRequest("User or CompanyId not found.");
            }

            var leaves = await _leaveRepository.FindAsync(l => l.Employee.CompanyId == user.CompanyId.Value);

            var getLeaveDtos = leaves.Select(l => new GetLeaveDTO
            {
                Id = l.Id,
                StartDate = l.StartDate,
                EndDate = l.EndDate,
                RequestedDate = l.RequestedDate,
                ApprovedById = l.ApprovedById,
                EmployeeId = l.EmployeeId,
                LeaveTypeId = l.LeaveTypeId,
                RequestStatusId = l.RequestStatusId
            }).ToList();

            return Ok(getLeaveDtos);
        }

        // GET: api/Leave/5
        [Authorize(Roles = "CompanyManager")]
        [HttpGet("{id}")]
        public async Task<ActionResult<GetLeaveDTO>> GetLeave(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userRepository.GetByIdAsync(int.Parse(userId));

            if (user == null || user.CompanyId == null)
            {
                return BadRequest("User or CompanyId not found.");
            }

            var leave = await _leaveRepository.GetByIdAsync(id);
            if (leave == null || leave.Employee.CompanyId != user.CompanyId)
            {
                return NotFound();
            }

            var getLeaveDto = new GetLeaveDTO
            {
                Id = leave.Id,
                StartDate = leave.StartDate,
                EndDate = leave.EndDate,
                RequestedDate = leave.RequestedDate,
                ApprovedById = leave.ApprovedById,
                EmployeeId = leave.EmployeeId,
                LeaveTypeId = leave.LeaveTypeId,
                RequestStatusId = leave.RequestStatusId
            };

            return Ok(getLeaveDto);
        }

        // POST: api/Leave
        [Authorize(Roles = "CompanyUser")]
        [HttpPost("CreateLeaveRequest")]
        public async Task<ActionResult<GetLeaveDTO>> CreateLeaveRequest(CreateLeaveDTO createLeaveDto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _context.Users.Include(u => u.Employee).FirstOrDefaultAsync(u => u.Id == int.Parse(userId));

            if (user == null || user.CompanyId == null)
            {
                return BadRequest("User or CompanyId not found.");
            }

            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == user.Employee.Id);

            var leave = new Leave
            {
                StartDate = createLeaveDto.StartDate,
                EndDate = createLeaveDto.EndDate,
                RequestedDate = DateTime.Now,
                LeaveTypeId = createLeaveDto.LeaveTypeId,
                EmployeeId = employee.Id,
                RequestStatusId = 1, // Pending status
                ApprovedById = 0 // Null for now
            };

            await _leaveRepository.AddAsync(leave);

            var getLeaveDto = new GetLeaveDTO
            {
                Id = leave.Id,
                StartDate = leave.StartDate,
                EndDate = leave.EndDate,
                RequestedDate = leave.RequestedDate,
                ApprovedById = leave.ApprovedById,
                EmployeeId = leave.EmployeeId,
                LeaveTypeId = leave.LeaveTypeId,
                RequestStatusId = leave.RequestStatusId
            };

            return CreatedAtAction(nameof(GetLeave), new { id = leave.Id }, getLeaveDto);
        }

        // PUT: api/Leave/5
        [Authorize(Roles = "CompanyManager")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLeave(int id, CreateLeaveDTO updateLeaveDto)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userRepository.GetByIdAsync(int.Parse(userId));

            if (user == null || user.CompanyId == null)
            {
                return BadRequest("User or CompanyId not found.");
            }

            var leave = await _leaveRepository.GetByIdAsync(id);
            if (leave == null || leave.Employee.CompanyId != user.CompanyId)
            {
                return NotFound();
            }

            leave.StartDate = updateLeaveDto.StartDate;
            leave.EndDate = updateLeaveDto.EndDate;
            leave.LeaveTypeId = updateLeaveDto.LeaveTypeId;

            await _leaveRepository.UpdateAsync(leave);

            return NoContent();
        }

        // DELETE: api/Leave/5
        [Authorize(Roles = "CompanyManager")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLeave(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userRepository.GetByIdAsync(int.Parse(userId));

            if (user == null || user.CompanyId == null)
            {
                return BadRequest("User or CompanyId not found.");
            }

            var leave = await _leaveRepository.GetByIdAsync(id);
            if (leave == null || leave.Employee.CompanyId != user.CompanyId)
            {
                return NotFound();
            }

            await _leaveRepository.DeleteAsync(leave);

            return NoContent();
        }

        // PUT: api/Leave/UpdateLeaveStatus
        [Authorize(Roles = "CompanyManager")]
        [HttpPut("UpdateLeaveStatus")]
        public async Task<IActionResult> UpdateLeaveStatus(UpdateLeaveStatusDTO updateLeaveStatusDto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userRepository.GetByIdAsync(int.Parse(userId));

            if (user == null || user.CompanyId == null)
            {
                return BadRequest("User or CompanyId not found.");
            }

            var leave = await _leaveRepository.GetByIdAsync(updateLeaveStatusDto.Id);
            if (leave == null)
            {
                return NotFound();
            }

            leave.RequestStatusId = updateLeaveStatusDto.RequestStatusId;
            leave.ApprovedById = user.Id;

            await _leaveRepository.UpdateAsync(leave);

            return Ok();
        }

        // GET: api/Leave/MyLeaveCard
        [Authorize(Roles = "CompanyUser, CompanyManager, CompanyOwner")]
        [HttpGet("MyLeaveCard")]
        public async Task<ActionResult<LeaveCardDTO>> GetMyLeaveCard()
        {
            // Get the current user's ID from the claims
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Find the user in the database
            var user = await _context.Users
                .Include(u => u.Employee)
                .FirstOrDefaultAsync(u => u.Id == int.Parse(userId));

            if (user == null || user.Employee == null)
            {
                return BadRequest("User or Employee not found.");
            }

            // Use your service to get the leave card for the employee
            var leaveCard = await _leaveService.GetLeaveCardAsync(user.Employee.Id);

            if (leaveCard == null)
            {
                return NotFound("Leave card not found.");
            }

            return Ok(leaveCard);
        }

    }
}
