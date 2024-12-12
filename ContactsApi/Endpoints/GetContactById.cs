using FastEndpoints;
using ContactsApi.Extensions;
using ContactsApi.Core.Abstractions;

namespace ContactsApi.Endpoints
{
    public class GetContactById(IContactsService _contactsService) : Endpoint<GetContactByIdRequest, GetContactByIdResponse>
    {
        public override void Configure()
        {
            Get("/api/contacts/{ContactId}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(GetContactByIdRequest req, CancellationToken ct)
        {
            var result = await _contactsService.GetContactById(req.ContactId);

            await this.SendResponse(result, result => new GetContactByIdResponse(result.Value));
        }
    }
}
