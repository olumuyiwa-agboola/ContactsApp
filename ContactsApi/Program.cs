using FastEndpoints;
using Microsoft.OpenApi.Models;
using ContactsApi.Core.Services;
using ContactsApi.Infrastructure;
using ContactsApi.Core.Abstractions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen(c =>
{
    OpenApiInfo openApiInfo = new()
    {
        Version = "v1",
        Title = "Contacts API",
        Description = "A simple RESTful API that creates, reads, updates and deletes contacts, implemented in ASP.NET Core to practice the REPR pattern, the Result pattern, and Open API documentation with Swagger, using:\n - Ardalis.Result\n - Fast Endpoints\n - Scalar.AspNetCore\n - Ardalis.Result.AspNetCore\n - Microsoft.AspNetCore.OpenApi\n\nOther dependencies:\n - Dapper\n - Microsoft.Data.Sqlite\n\n.NET Version: 9.0"
    };

    c.SwaggerDoc("v1", openApiInfo);
});
builder.Services.AddFastEndpoints();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IContactsService, ContactsService>();
builder.Services.AddScoped<IContactsService, ContactsService>();
builder.Services.AddScoped<IContactsRepository, ContactsRepository>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.InjectStylesheet("/swagger-ui/SwaggerDark.css");
});
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseFastEndpoints();
app.Run();