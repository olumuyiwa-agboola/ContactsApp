using FastEndpoints;
using ContactsApi.Extensions;
using ContactsApi.Core.Abstractions;

namespace ContactsApi.Endpoints
{
    public class GetAllContacts(IContactsService _contactsService) : EndpointWithoutRequest<GetAllContactsResponse>
    {
        public override void Configure()
        {
            Get("/api/contacts");
            Description(b => b
            .WithSummary("Get all contacts")
            .WithDescription(@"This endpoint retrieves the details of all the contacts 
                            from the database. It takes no input.")
            );
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var result = await _contactsService.GetAllContacts();

            await this.SendResponse(result, result => new GetAllContactsResponse(result.Value));
        }
    }
}
