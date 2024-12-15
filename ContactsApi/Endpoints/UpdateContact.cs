using FastEndpoints;
using ContactsApi.Extensions;
using ContactsApi.Core.Abstractions;

namespace ContactsApi.Endpoints
{
    public class UpdateContact(IContactsService _contactsService) : Endpoint<UpdateContactRequest, UpdateContactResponse>
    {
        public override void Configure()
        {
            Put("/api/contacts/{contactId}");
            Description(b => b
            .WithSummary("Update a contact")
            .WithDescription(@"This endpoint updates one or more of the properties of an existing
                                contact. It takes the contacts details (first name, last name, email 
                                address and phone number) in the request body and the unique identifier 
                                for the contact (contactId) as a route parameter.")
            );
            AllowAnonymous();
        }

        public override async Task HandleAsync(UpdateContactRequest req, CancellationToken ct)
        {
            var (contactId, newFirstName, newLastName, newEmailAddress, newPhoneNumber) = req;
            
            var result = await _contactsService.UpdateContact(contactId, newFirstName, newLastName, newEmailAddress, newPhoneNumber);

            await this.SendResponse(result, result => new UpdateContactResponse(result.Value));
        }
    }
}
