using System;
using FluentValidation;
using HRMS.CORE.DTOs;

namespace HRMS.BUSINESS.Validators;
public class CreateAddressDTOValidator : AbstractValidator<CreateAddressDTO>
{
    public CreateAddressDTOValidator()
    {
        RuleFor(x => x.StreetAddress).NotEmpty().WithMessage("Street Address is required.");
        RuleFor(x => x.PostalCode).NotEmpty().WithMessage("Postal Code is required.");
        RuleFor(x => x.City).NotEmpty().WithMessage("City is required.");
        RuleFor(x => x.Country).NotEmpty().WithMessage("Country is required.");
    }
}