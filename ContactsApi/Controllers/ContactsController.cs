using ContactsApi.Models;
using ContactsApi.Exceptions;
using ContactsApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ContactsApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContactsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetContacts()
    {
        try
        {
            List<Contact> contacts = ContactRepo.GetAllContacts();
            return Ok(contacts);
        }
        catch
        {
            Error error = new()
            {
                status = 500,
                title = "Internal Server Error",
                message = "An error occurred while processing your request. Please try again later."
            };

            return StatusCode(500, error);
        }
    }

    [HttpGet("{id}")]
    public IActionResult GetContact(int id)
    {
        try
        {
            Contact contact = ContactRepo.GetContactById(id);
            return Ok(contact);
        }
        catch (Exception ex)
        {
            if (ex is NotFoundException)
            {
                Error error = new()
                {
                    status = 404,
                    title = "Not Found",
                    message = $"{ex.Message}"
                };

                return NotFound(error);
            }
            else
                return BadRequest();
        }
    }

    [HttpPost]
    public IActionResult AddContact(AddContactRequest request)
    {
        try
        {
            AddContactResponse response = ContactRepo.AddContact(request);
            return Ok(response);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message.ToString());
            return BadRequest();
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteContact(int id)
    {
        try
        {
            DeleteContactResponse response = ContactRepo.DeleteContact(id);
            return Ok(response);
        }
        catch(Exception ex)
        {
            if (ex is NotFoundException)
            {
                Error error = new()
                {
                    status = 404,
                    title = "Not Found",
                    message = $"{ex.Message}"
                };

                return NotFound(error);
            }
            else
                return BadRequest();
        }

    }

    [HttpPut("{id}")]
    public IActionResult UpdateContact(int id, UpdateContactRequest request)
    {
        try
        {
            UpdateContactResponse response = ContactRepo.UpdateContact(id, request);
            return Ok(response);
        }
        catch (Exception ex)
        {
            if (ex is NotFoundException)
            {
                Error error = new()
                {
                    status = 404,
                    title = "Not Found",
                    message = $"{ex.Message}"
                };

                return NotFound(error);
            }
            else
                return BadRequest();
        }
    }
}
