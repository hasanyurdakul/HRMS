using System;
using System.Security.Claims;
using HRMS.CORE;
using HRMS.CORE.DTOs;
using HRMS.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRMS.API.Controllers;


[Authorize(Roles = "CompanyManager")]
[Route("api/[controller]")]
[ApiController]
public class DepartmentController : ControllerBase
{
    private readonly IDepartmentRepository _departmentRepository;
    private readonly IUserRepository _userRepository;
    private readonly AppDbContext _context;

    public DepartmentController(IDepartmentRepository departmentRepository, IUserRepository userRepository, AppDbContext context)
    {
        _departmentRepository = departmentRepository;
        _userRepository = userRepository;
        _context = context;
    }

    // GET: api/Department
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetDepartmentDTO>>> GetDepartments()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var user = await _userRepository.GetByIdAsync(int.Parse(userId));

        if (user == null || user.CompanyId == null)
        {
            return BadRequest("User or CompanyId not found.");
        }

        var departments = await _context.Departments.Where(d => d.CompanyId == user.CompanyId).ToListAsync();

        if (departments == null || !departments.Any())
        {
            return NotFound("No departments found for this company.");
        }

        var getDepartmentDtos = departments.Select(d => new GetDepartmentDTO
        {
            Id = d.Id,
            Name = d.Name,
            CompanyId = d.CompanyId
        }).ToList();

        return Ok(getDepartmentDtos);
    }

    // GET: api/Department/5
    [HttpGet("{id}")]
    public async Task<ActionResult<GetDepartmentDTO>> GetDepartment(int id)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var user = await _userRepository.GetByIdAsync(int.Parse(userId));

        if (user == null || user.CompanyId == null)
        {
            return BadRequest("User or CompanyId not found.");
        }

        var department = await _departmentRepository.GetByIdAsync(id);
        if (department == null || department.CompanyId != user.CompanyId)
        {
            return NotFound();
        }

        var getDepartmentDto = new GetDepartmentDTO
        {
            Id = department.Id,
            Name = department.Name,
            CompanyId = department.CompanyId
        };

        return Ok(getDepartmentDto);
    }

    // POST: api/Department
    [HttpPost]
    public async Task<ActionResult<GetDepartmentDTO>> PostDepartment(CreateDepartmentDTO createDepartmentDto)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var user = await _userRepository.GetByIdAsync(int.Parse(userId));

        if (user == null || user.CompanyId == null)
        {
            return BadRequest("User or CompanyId not found.");
        }

        var department = new Department
        {
            Name = createDepartmentDto.Name,
            CompanyId = user.CompanyId.Value,
            isActive = true
        };

        await _departmentRepository.AddAsync(department);

        var getDepartmentDto = new GetDepartmentDTO
        {
            Id = department.Id,
            Name = department.Name,
            CompanyId = department.CompanyId
        };

        return CreatedAtAction(nameof(GetDepartment), new { id = department.Id }, getDepartmentDto);
    }

    // PUT: api/Department/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutDepartment(int id, UpdateDepartmentDTO updateDepartmentDto)
    {
        if (id != updateDepartmentDto.Id)
        {
            return BadRequest();
        }

        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var user = await _userRepository.GetByIdAsync(int.Parse(userId));

        if (user == null || user.CompanyId == null)
        {
            return BadRequest("User or CompanyId not found.");
        }

        var department = await _departmentRepository.GetByIdAsync(id);
        if (department == null || department.CompanyId != user.CompanyId)
        {
            return NotFound();
        }

        department.Name = updateDepartmentDto.Name;

        await _departmentRepository.UpdateAsync(department);

        return NoContent();
    }

    // DELETE: api/Department/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDepartment(int id)
    {
        var department = await _departmentRepository.GetByIdAsync(id);
        department.isActive = false;
        await _departmentRepository.UpdateAsync(department);

        return Ok("Department deleted successfully.");
    }
}