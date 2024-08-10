using System;
using FluentValidation;
using HRMS.CORE.DTOs;

namespace HRMS.BUSINESS.Validators;

public class UpdateLeaveStatusDTOValidator : AbstractValidator<UpdateLeaveStatusDTO>
{
    public UpdateLeaveStatusDTOValidator()
    {
        RuleFor(x => x.RequestStatusId).GreaterThan(0).WithMessage("Request Status Id is required.");
    }
}