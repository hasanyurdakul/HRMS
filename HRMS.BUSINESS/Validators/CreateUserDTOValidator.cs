using System;
using FluentValidation;
using HRMS.CORE;

namespace HRMS.BUSINESS.Validators;

public class CreateUserDTOValidator : AbstractValidator<CreateUserDTO>
{
    public CreateUserDTOValidator()
    {
        RuleFor(x => x.Username).NotEmpty().WithMessage("Username is required.");
        RuleFor(x => x.Email).EmailAddress().WithMessage("Valid email is required.");
    }
}