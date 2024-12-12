using FastEndpoints;
using FluentValidation;

namespace ContactsApi.Endpoints
{
    public class GetContactByIdValidator : Validator<GetContactByIdRequest>
    {
        public GetContactByIdValidator()
        {
            RuleFor(model => model.ContactId)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Matches(@"^\d+$").WithMessage("{PropertyName} must contain only digits");
        }
    }
}
