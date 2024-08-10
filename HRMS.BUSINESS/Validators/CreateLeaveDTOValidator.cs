using System;
using FluentValidation;
using HRMS.CORE.DTOs;

namespace HRMS.BUSINESS.Validators;

public class CreateLeaveDTOValidator : AbstractValidator<CreateLeaveDTO>
{
    public CreateLeaveDTOValidator()
    {
        RuleFor(x => x.StartDate).LessThanOrEqualTo(x => x.EndDate).WithMessage("Start Date must be before End Date.");
        RuleFor(x => x.LeaveTypeId).GreaterThan(0).WithMessage("Leave Type Id is required.");
    }
}