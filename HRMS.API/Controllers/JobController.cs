using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using HRMS.CORE;
using HRMS.DAL;
using HRMS.CORE.DTOs;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace HRMS.API.Controllers
{
    [Authorize(Roles = "CompanyManager")]
    [ApiController]
    [Route("api/[controller]")]
    public class JobController : ControllerBase
    {
        private readonly IJobRepository _jobRepository;
        private readonly IUserRepository _userRepository;
        private readonly AppDbContext _context;

        public JobController(IJobRepository jobRepository, IUserRepository userRepository, AppDbContext context)
        {
            _jobRepository = jobRepository;
            _userRepository = userRepository;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobDTO>>> GetJobs()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userRepository.GetByIdAsync(int.Parse(userId));
            var companyId = user.CompanyId;

            if (companyId == null)
            {
                return Forbid();
            }

            var jobs = await _context.Jobs.Where(j => j.CompanyId == companyId).Where(j => j.isActive == true).ToListAsync();
            var jobDTOs = jobs.Select(job => new JobDTO
            {
                Id = job.Id,
                Title = job.Title
            }).ToList();

            return Ok(jobDTOs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<JobDTO>> GetJob(int id)
        {
            var job = await _jobRepository.GetByIdAsync(id);

            if (job == null)
            {
                return NotFound();
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userRepository.GetByIdAsync(int.Parse(userId));
            var companyId = user.CompanyId;

            if (job.CompanyId != companyId)
            {
                return Forbid();
            }

            var jobDTO = new JobDTO
            {
                Id = job.Id,
                Title = job.Title
            };

            return Ok(jobDTO);
        }

        [HttpPost]
        public async Task<ActionResult<JobDTO>> CreateJob(CreateJobDTO createJobDTO)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userRepository.GetByIdAsync(int.Parse(userId));
            var companyId = user.CompanyId;

            if (companyId == null)
            {
                return Forbid();
            }

            var job = new Job
            {
                Title = createJobDTO.Title,
                CompanyId = companyId.Value,
                isActive = true
            };

            await _jobRepository.AddAsync(job);

            var jobDTO = new JobDTO
            {
                Id = job.Id,
                Title = job.Title
            };

            return CreatedAtAction(nameof(GetJob), new { id = job.Id }, jobDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateJob(int id, UpdateJobDTO updateJobDTO)
        {
            if (id != updateJobDTO.Id)
            {
                return BadRequest();
            }

            var existingJob = await _jobRepository.GetByIdAsync(id);

            if (existingJob == null)
            {
                return NotFound();
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userRepository.GetByIdAsync(int.Parse(userId));
            var companyId = user.CompanyId;

            if (existingJob.CompanyId != companyId)
            {
                return Forbid();
            }

            existingJob.Title = updateJobDTO.Title;

            await _jobRepository.UpdateAsync(existingJob);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJob(int id)
        {
            var job = await _jobRepository.GetByIdAsync(id);
            job.isActive = false;
            await _jobRepository.UpdateAsync(job);

            return Ok("Job deleted successfully.");
        }
    }
}











