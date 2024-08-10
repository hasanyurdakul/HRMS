using System;
using FluentValidation;
using HRMS.CORE;

namespace HRMS.BUSINESS.Validators;

public class CalendarEventDTOValidator : AbstractValidator<CalendarEventDTO>
{
    public CalendarEventDTOValidator()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required.");
        RuleFor(x => x.Start).LessThanOrEqualTo(x => x.End).WithMessage("Start date must be before End date.");
        RuleFor(x => x.Type).NotEmpty().WithMessage("Type is required.");
    }
}