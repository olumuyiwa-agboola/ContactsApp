using FastEndpoints;
using Scalar.AspNetCore;
using ContactsApi.Core.Services;
using ContactsApi.Infrastructure;
using ContactsApi.Core.Abstractions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFastEndpoints();
builder.Services.AddOpenApi("openapi-doc", options =>
{
    options.AddDocumentTransformer((document, context, cancellationToken) =>
    {
        document.Info = new()
        {
            Title = "Contacts API",
            Version = "v1",
            Description = "A simple RESTful API that creates, reads, updates and deletes contacts, implemented in ASP.NET Core to practice the REPR pattern, the Result pattern, and Open API documentation with Scalar, using:\n- Ardalis.Result\n- Fast Endpoints\n- Scalar.AspNetCore\n- Ardalis.Result.AspNetCore\n- Microsoft.AspNetCore.OpenApi\n\nOther dependencies:\n- Dapper\n- Microsoft.Data.Sqlite\n\n.NET Version: 9.0"
        };
        return Task.CompletedTask;
    });
});
builder.Services.AddScoped<IContactsService, ContactsService>();
builder.Services.AddScoped<IContactsService, ContactsService>();
builder.Services.AddScoped<IContactsRepository, ContactsRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi(); 
    app.MapScalarApiReference(options =>
    {
        options
        .WithEndpointPrefix("/{documentName}")
        .WithTitle("Contacts API - OpenAPI Documentation")
        .WithFavicon("https://img.icons8.com/?size=100&id=FXYjTaZ8d2Br&format=png&color=000000");
    });
}

app.UseHttpsRedirection();
app.UseFastEndpoints();

app.Run();