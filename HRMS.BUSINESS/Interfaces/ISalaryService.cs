using System;
using HRMS.CORE.DTOs;

namespace HRMS.BUSINESS.Interfaces;

public interface ISalaryService
{
    public Task<IEnumerable<SalaryDTO>> GetSalaries();
    public Task<SalaryDTO> GetSalary(int id);
    public Task<SalaryDTO> AddSalary(SalaryDTO salary);
    public Task<SalaryDTO> UpdateSalary(int id, SalaryDTO salary);
    public Task<SalaryDTO> DeleteSalary(int id);
}
