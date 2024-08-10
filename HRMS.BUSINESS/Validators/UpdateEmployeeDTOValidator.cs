using System;
using FluentValidation;
using HRMS.CORE.DTOs;

namespace HRMS.BUSINESS.Validators;

public class UpdateEmployeeDTOValidator : AbstractValidator<UpdateEmployeeDTO>
{
    public UpdateEmployeeDTOValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().When(x => x.FirstName != null).WithMessage("First Name is required.");
        RuleFor(x => x.LastName).NotEmpty().When(x => x.LastName != null).WithMessage("Last Name is required.");
        RuleFor(x => x.Email).EmailAddress().When(x => x.Email != null).WithMessage("Valid email is required.");
        RuleFor(x => x.PhoneNumber).NotEmpty().When(x => x.PhoneNumber != null).WithMessage("Phone Number is required.");
        RuleFor(x => x.HireDate).LessThanOrEqualTo(DateTime.Today).When(x => x.HireDate.HasValue).WithMessage("Hire Date cannot be in the future.");
        RuleFor(x => x.BirthDate).LessThanOrEqualTo(DateTime.Today).When(x => x.BirthDate.HasValue).WithMessage("Birth Date cannot be in the future.");
    }
}