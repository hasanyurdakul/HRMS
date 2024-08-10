using System;
using FluentValidation;
using HRMS.CORE.DTOs;

namespace HRMS.BUSINESS.Validators;

public class UpdateJobDTOValidator : AbstractValidator<UpdateJobDTO>
{
    public UpdateJobDTOValidator()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage("Job Title is required.");
    }
}