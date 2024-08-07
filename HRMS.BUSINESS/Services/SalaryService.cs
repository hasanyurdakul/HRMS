using System;
using HRMS.BUSINESS.Interfaces;
using HRMS.CORE;
using HRMS.CORE.DTOs;

namespace HRMS.BUSINESS.Services;

public class SalaryService : ISalaryService
{

    private readonly ISalaryRepository _salaryRepository;
    private readonly IEmployeeRepository _employeeRepository;

    public SalaryService(ISalaryRepository salaryRepository, IEmployeeRepository employeeRepository)
    {
        _salaryRepository = salaryRepository;
        _employeeRepository = employeeRepository;
    }
    public async Task<SalaryDTO> AddSalary(SalaryDTO salaryDto)
    {
        if (salaryDto == null) throw new ArgumentNullException(nameof(salaryDto));

        var employee = await _employeeRepository.GetByIdAsync(salaryDto.EmployeeId);
        if (employee == null)
        {
            throw new ArgumentException("Invalid Employee ID.");
        }



        var salary = new Salary
        {
            EmployeeId = salaryDto.EmployeeId,
            Amount = salaryDto.Amount ?? 0 // Null ise 0 olarak ayarla
        };

        await _salaryRepository.AddAsync(salary);

        salaryDto.SalaryId = salary.Id;

        return salaryDto;
    }

    public async Task<SalaryDTO> DeleteSalary(int id)
    {
        var salary = await _salaryRepository.GetByIdAsync(id);
        if (salary == null)
        {
            throw new KeyNotFoundException("Salary not found.");
        }

        await _salaryRepository.DeleteAsync(salary);

        return new SalaryDTO
        {
            SalaryId = salary.Id,
            EmployeeId = salary.EmployeeId,
            Amount = salary.Amount
        };
    }

    public async Task<IEnumerable<SalaryDTO>> GetSalaries()
    {
        var salaries = await _salaryRepository.GetAllAsync();
        var salaryDtos = new List<SalaryDTO>();

        foreach (var salary in salaries)
        {
            salaryDtos.Add(new SalaryDTO
            {
                SalaryId = salary.Id,
                EmployeeId = salary.EmployeeId,
                Amount = salary.Amount
            });
        }

        return salaryDtos;
    }

    public async Task<SalaryDTO> GetSalary(int id)
    {
        var salary = await _salaryRepository.GetByIdAsync(id);
        if (salary == null)
        {
            throw new KeyNotFoundException("Salary not found.");
        }

        return new SalaryDTO
        {
            SalaryId = salary.Id,
            EmployeeId = salary.EmployeeId,
            Amount = salary.Amount
        };
    }

    public async Task<SalaryDTO> UpdateSalary(int id, SalaryDTO salaryDto)
    {
        if (salaryDto == null) throw new ArgumentNullException(nameof(salaryDto));

        var salary = await _salaryRepository.GetByIdAsync(id);
        if (salary == null)
        {
            throw new KeyNotFoundException("Salary not found.");
        }

        salary.EmployeeId = salaryDto.EmployeeId;
        salary.Amount = salaryDto.Amount ?? salary.Amount; // Null değilse güncelle

        await _salaryRepository.UpdateAsync(salary);

        return new SalaryDTO
        {
            SalaryId = salary.Id,
            EmployeeId = salary.EmployeeId,
            Amount = salary.Amount
        };
    }
}
