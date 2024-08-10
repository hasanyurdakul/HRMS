using System;
using FluentValidation;
using HRMS.CORE.DTOs;

namespace HRMS.BUSINESS.Validators;

public class CreateEmployeeDTOValidator : AbstractValidator<CreateEmployeeDTO>
{
    public CreateEmployeeDTOValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().WithMessage("First Name is required.");
        RuleFor(x => x.LastName).NotEmpty().WithMessage("Last Name is required.");
        RuleFor(x => x.Email).EmailAddress().WithMessage("Valid email is required.");
        RuleFor(x => x.HireDate).LessThanOrEqualTo(DateTime.Today).WithMessage("Hire Date cannot be in the future.");
        RuleFor(x => x.BirthDate).LessThanOrEqualTo(DateTime.Today).WithMessage("Birth Date cannot be in the future.");
        RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Phone Number is required.");
        RuleFor(x => x.RemainingLeaveDays).GreaterThanOrEqualTo(0).WithMessage("Remaining Leave Days cannot be negative.");
        RuleFor(x => x.EducationLevelId).GreaterThan(0).WithMessage("Education Level Id is required.");
        RuleFor(x => x.GenderId).GreaterThan(0).WithMessage("Gender Id is required.");
        RuleFor(x => x.JobId).GreaterThan(0).WithMessage("Job Id is required.");
        RuleFor(x => x.DepartmentId).GreaterThan(0).WithMessage("Department Id is required.");
        RuleFor(x => x.createAddressDTO).SetValidator(new CreateAddressDTOValidator());
        RuleFor(x => x.SalaryDTO).SetValidator(new SalaryDTOValidator());
    }
}