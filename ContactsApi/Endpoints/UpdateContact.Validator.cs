using FastEndpoints;
using FluentValidation;
using System.Text.RegularExpressions;

namespace ContactsApi.Endpoints
{
    public class UpdateContactValidator : Validator<UpdateContactRequest>
    {
        public UpdateContactValidator()
        {
            RuleFor(model => model.ContactId)
                .NotEmpty().WithMessage("{PropertyName} is required")
                 .Length(5).WithMessage("{PropertyName} must contain {MaxLength} digits");

            RuleFor(model => model.FirstName)
                .NotEmpty().WithMessage("{PropertyName} is required")
                 .MaximumLength(50).WithMessage("{PropertyName} must not exceed {MaxLength} characters");

            RuleFor(model => model.LastName)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {MaxLength} characters");

            RuleFor(model => model.Email)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .EmailAddress().WithMessage("{PropertyName} is not a valid email address")
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed {MaxLength} characters");

            RuleFor(model => model.PhoneNumber)
                .NotEmpty().WithMessage("{PropertyName} is required");

            When(model => !string.IsNullOrWhiteSpace(model.PhoneNumber), () =>
            {
                RuleFor(model => model.PhoneNumber)
                .Custom((input, context) =>
                {
                    if (!string.IsNullOrWhiteSpace(input) && (input.Length == 11 || input.Length == 14))
                    {
                        if (!Regex.IsMatch(input, @"^(070|080|081|090|091)\d{8}$") && !Regex.IsMatch(input, @"^(\+23470|\+23480|\+23490|\+23471|\+23481|\+23491)\d{8}$"))
                        {
                            context.AddFailure("phone Number must be a valid Nigerian phone number");
                        }
                    }
                    else
                    {
                        context.AddFailure("phone Number must be a valid Nigerian phone number");
                    }
                });
            });
        }
    }
}
