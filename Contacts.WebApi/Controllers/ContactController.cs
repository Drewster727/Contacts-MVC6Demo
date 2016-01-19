using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using Contacts.Repository;
using Contacts.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Contacts.Controllers
{
  [Route("api/[controller]")]
  public class ContactController : Controller
  {
    [FromServices]
    public IContactRepository ContactsRepo { get; set; }

    [Route("DoSomething")]
    public string DoSomething()
    {
      return "testing...";
    }

    [Route("AllContacts")]
    [HttpGet]
    public IEnumerable<Contact> GetAll()
    {
      return ContactsRepo.GetAll();
    }

    // GET: api/values
    //[Produces("application/json")]
    [HttpGet("{id}", Name = "GetContacts")]
    public IActionResult Get(string id)
    {
      Contact contact = ContactsRepo.Find(id);
      return new ObjectResult(new Contact()
      {
        FirstName = "Drew",
        LastName = "McMinn",
        MobilePhone = "(913)449-0977"
      });
      if (contact == null) return HttpNotFound();
      return new ObjectResult(contact);
    }

    
  }
}
