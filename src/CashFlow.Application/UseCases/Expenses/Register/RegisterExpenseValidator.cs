using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using FluentValidation;

namespace CashFlow.Application.UseCases.Expenses.Register;

public class RegisterExpenseValidator : AbstractValidator<RequestExpenseJson>
{
    public RegisterExpenseValidator()
    {
        RuleFor(expense => expense.Title).NotEmpty().WithMessage("The title is required");
        RuleFor(expense => expense.Amount).GreaterThan(0).WithMessage("The amout must be greater than 0");
        RuleFor(expense => expense.Date).LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Expenses cannot be for the future");
        RuleFor(expense => expense.PaymentType).IsInEnum().WithMessage("Payment type is not valid.");
    }
}
