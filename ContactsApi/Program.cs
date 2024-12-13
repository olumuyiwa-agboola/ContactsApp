using FastEndpoints;
using Scalar.AspNetCore;
using ContactsApi.Core.Services;
using ContactsApi.Infrastructure;
using ContactsApi.Core.Abstractions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFastEndpoints();
builder.Services.AddOpenApi("scalar-open-api-doc", options =>
{
    options.AddDocumentTransformer((document, context, cancellationToken) =>
    {
        document.Info = new()
        {
            Title = "Contacts API",
            Version = "v1",
            Description = "A simple RESTful API that creates, reads, updates and deletes contacts, as an experiment on the implementation of web APIs using the following concepts and tools:\n- REPR Pattern\n- Fast Endpoints\n- Results Pattern\n- Scalar.AspNetCore\n- Microsoft.AspNetCore.OpenApi"
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
        options.WithEndpointPrefix("/{documentName}");
    });
}

app.UseHttpsRedirection();
app.UseFastEndpoints();

app.Run();