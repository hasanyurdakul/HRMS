using System;
using FluentValidation;
using HRMS.CORE.DTOs;

namespace HRMS.BUSINESS.Validators;

public class CreateResumeDTOValidator : AbstractValidator<CreateResumeDTO>
{
    public CreateResumeDTOValidator()
    {
        RuleFor(x => x.Path).NotEmpty().WithMessage("Path is required.");
        RuleFor(x => x.CompanyId).GreaterThan(0).When(x => x.CompanyId.HasValue).WithMessage("Company Id should be greater than 0.");
    }
}