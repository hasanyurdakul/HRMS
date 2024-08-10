using System;
using FluentValidation;
using HRMS.CORE.DTOs;

namespace HRMS.BUSINESS.Validators;

public class SalaryDTOValidator : AbstractValidator<SalaryDTO>
{
    public SalaryDTOValidator()
    {
        RuleFor(x => x.EmployeeId).GreaterThan(0).WithMessage("Employee Id is required.");
        RuleFor(x => x.Amount).GreaterThan(0).WithMessage("Amount should be greater than 0.");
    }
}