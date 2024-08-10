using System;
using FluentValidation;
using HRMS.CORE;

namespace HRMS.BUSINESS.Validators;

public class CreateCompanyDTOValidator : AbstractValidator<CreateCompanyDTO>
{
    public CreateCompanyDTOValidator()
    {
        RuleFor(x => x.CompanyName).NotEmpty().WithMessage("Company Name is required.");
        RuleFor(x => x.CompanyEmail).EmailAddress().WithMessage("Valid email is required.");
        RuleFor(x => x.CompanyPhoneNumber).NotEmpty().WithMessage("Company Phone Number is required.");
        RuleFor(x => x.createAddressDTO).SetValidator(new CreateAddressDTOValidator());
    }
}