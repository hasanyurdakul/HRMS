using System;
using FluentValidation;
using HRMS.CORE.DTOs;

namespace HRMS.BUSINESS.Validators;

public class CreateExpenseDTOValidator : AbstractValidator<CreateExpenseDTO>
{
    public CreateExpenseDTOValidator()
    {
        RuleFor(x => x.Amount).GreaterThan(0).WithMessage("Amount should be greater than 0.");
        RuleFor(x => x.ExpenseDate).LessThanOrEqualTo(DateTime.Today).WithMessage("Expense Date cannot be in the future.");
    }
}