using FastEndpoints;
using ContactsApi.Extensions;
using ContactsApi.Core.Abstractions;

namespace ContactsApi.Endpoints
{
    public class AddContact(IContactsService _contactsService) : Endpoint<AddContactRequest, AddContactResponse>
    {
        public override void Configure()
        {
            Post("/api/contacts");
            Description(b => b
            .WithSummary("Create a contact")
            .WithDescription(@"This endpoint creates and saves a new contact. 
                               It takes as the input, the first name, last name, 
                               email address and phone number of the contact.")
            );
            AllowAnonymous();
        }

        public override async Task HandleAsync(AddContactRequest req, CancellationToken ct)
        {
            var result = await _contactsService.AddContact(req.FirstName!, req.LastName!, req.Email!, req.PhoneNumber!);

            await this.SendResponse(result, result => new AddContactResponse(result.Value));
        }
    }
}
