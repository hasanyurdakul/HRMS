using System;
using FluentValidation;
using HRMS.CORE.DTOs;

namespace HRMS.BUSINESS.Validators;

public class CreateDepartmentDTOValidator : AbstractValidator<CreateDepartmentDTO>
{
    public CreateDepartmentDTOValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Department Name is required.");
    }
}