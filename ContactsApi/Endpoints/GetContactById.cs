using FastEndpoints;
using ContactsApi.Extensions;
using ContactsApi.Core.Abstractions;

namespace ContactsApi.Endpoints
{
    public class GetContactById(IContactsService _contactsService) : Endpoint<GetContactByIdRequest, GetContactByIdResponse>
    {
        public override void Configure()
        {
            Get("/api/contacts/{contactId}");
            Description(b => b
            .WithSummary("Get contact by Id")
            .WithDescription(@"This endpoint retrieves the details of a particular 
                            contact from the database. It takes as the only input, the 
                            unique identifier (contactId) of the contact as a route parameter.")
            );
            AllowAnonymous();
        }

        public override async Task HandleAsync(GetContactByIdRequest req, CancellationToken ct)
        {
            var result = await _contactsService.GetContactById(req.ContactId);

            await this.SendResponse(result, result => new GetContactByIdResponse(result.Value));
        }
    }
}
