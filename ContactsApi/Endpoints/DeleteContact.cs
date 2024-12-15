using FastEndpoints;
using ContactsApi.Extensions;
using ContactsApi.Core.Abstractions;

namespace ContactsApi.Endpoints
{
    public class DeleteContact(IContactsService _contactsService) : Endpoint<DeleteContactRequest, DeleteContactResponse>
    {
        public override void Configure()
        {
            Delete("/api/contacts/{contactId}");
            Description(b => b
            .WithSummary("Delete contact")
            .WithDescription(@"This endpoint deletes a contact from the database. It takes as the only 
                            input, the unique identifier (contactId) of the contact as a route parameter.")
            );
            AllowAnonymous();
        }

        public override async Task HandleAsync(DeleteContactRequest req, CancellationToken ct)
        {
            var result = await _contactsService.DeleteContact(req.ContactId);

            await this.SendResponse(result, result => new DeleteContactResponse());
        }
    }
}
