using FastEndpoints;
using ContactsApi.Core.Services;
using ContactsApi.Infrastructure;
using ContactsApi.Core.Abstractions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddFastEndpoints();
builder.Services.AddScoped<IContactsService, ContactsService>();
builder.Services.AddScoped<IContactsService, ContactsService>();
builder.Services.AddScoped<IContactsRepository, ContactsRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseFastEndpoints();

app.Run();