using System;
using FluentValidation;
using HRMS.CORE.DTOs;

namespace HRMS.BUSINESS.Validators;

public class CreateJobDTOValidator : AbstractValidator<CreateJobDTO>
{
    public CreateJobDTOValidator()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage("Job Title is required.");
    }
}