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
            AllowAnonymous();
        }

        public override async Task HandleAsync(AddContactRequest req, CancellationToken ct)
        {
            var result = await _contactsService.AddContact(req.FirstName!, req.LastName!, req.Email!, req.PhoneNumber!);
            
            await this.SendResponse(result, result => new AddContactResponse(result.Value));
        }
    }
}
