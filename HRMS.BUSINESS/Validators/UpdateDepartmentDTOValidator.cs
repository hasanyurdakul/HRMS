using System;
using FluentValidation;
using HRMS.CORE.DTOs;

namespace HRMS.BUSINESS.Validators;

public class UpdateDepartmentDTOValidator : AbstractValidator<UpdateDepartmentDTO>
{
    public UpdateDepartmentDTOValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Department Name is required.");
    }
}