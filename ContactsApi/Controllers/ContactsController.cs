using ContactsApi.Models;
using ContactsApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ContactsApi.Controllers;

[ApiController]
[Route("api/Contacts")]
public class ContactsController : ControllerBase
{
    [HttpGet]
    [Route("GetContacts")]
    public IActionResult GetContacts()
    {
        List<ContactDTO> contacts = ContactRepo.GetAllContacts();
      
       return Ok(contacts);
    }

}
