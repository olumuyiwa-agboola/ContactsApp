using FastEndpoints;
using Scalar.AspNetCore;
using ContactsApi.Core.Services;
using ContactsApi.Infrastructure;
using ContactsApi.Core.Abstractions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFastEndpoints();
builder.Services.AddOpenApi("scalar-open-api-doc");
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