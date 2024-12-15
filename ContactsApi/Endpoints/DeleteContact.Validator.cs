using FastEndpoints;
using FluentValidation;

namespace ContactsApi.Endpoints
{
    public class DeleteContactValidator : Validator<DeleteContactRequest>
    {
        public DeleteContactValidator()
        {
            RuleFor(model => model.ContactId)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Matches(@"^\d+$").WithMessage("{PropertyName} must contain only digits");
        }
    }
}
