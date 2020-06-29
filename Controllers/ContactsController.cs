using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using MySql.Data.MySqlClient;
using Contacts.Business;
using Contacts.Models;

namespace Contacts.Controllers
{
  [Route("api/v1/contacts"), ApiController]
  public class ContactsController : ControllerBase
  {
    private readonly IContactBusiness _ContactBusiness;

    public ContactsController(IContactBusiness contactBusiness)
    {
      _ContactBusiness = contactBusiness;
    }

    [HttpPost]
    public async Task<IActionResult> PostContact([FromBody] Contact contact)
    {
      try
      {
        if (!ModelState.IsValid)
          return BadRequest(ModelState);

        await _ContactBusiness.Add(contact);

        return CreatedAtAction("GetContact", new { id = contact.Id }, contact);
      }
      catch (DbUpdateException ex) when (ex.InnerException is MySqlException sqlException && sqlException.Number == 1062)
      {
        return BadRequest(new
        {
          fullName = new List<string>() { "A contact with this name already exists." }
        });
      }
      catch
      {
        return StatusCode((int)HttpStatusCode.InternalServerError);
      }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutContact([FromRoute] int id, [FromBody] Contact contact)
    {
      try
      {
        if (!ModelState.IsValid)
          return BadRequest(ModelState);

        if (id != contact.Id)
          return BadRequest();

        await _ContactBusiness.Edit(id, contact);

        return NoContent();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!await _ContactBusiness.Exists(id))
          return NotFound();
        else
          throw;
      }
      catch (DbUpdateException ex) when (ex.InnerException is MySqlException sqlException && sqlException.Number == 1062)
      {
        return BadRequest(new
        {
          fullName = new List<string>() { "A contact with this name already exists." }
        });
      }
      catch
      {
        return StatusCode((int)HttpStatusCode.InternalServerError);
      }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteContact([FromRoute] int id)
    {
      try
      {
        if (!ModelState.IsValid)
          return BadRequest(ModelState);

        var contact = await _ContactBusiness.Find(id);

        if (contact == null)
          return NotFound();

        await _ContactBusiness.Del(contact);

        return Ok(contact);
      }
      catch
      {
        return StatusCode((int)HttpStatusCode.InternalServerError);
      }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetContact([FromRoute] int id)
    {
      try
      {
        if (!ModelState.IsValid)
          return BadRequest(ModelState);

        var contact = await _ContactBusiness.Find(id);

        if (contact == null)
          return NotFound();

        return Ok(contact);
      }
      catch
      {
        return StatusCode((int)HttpStatusCode.InternalServerError);
      }
    }

    [HttpGet, Route("favorites")]
    public async Task<IActionResult> GetFavoriteContacts()
    {
      try
      {
        return Ok(await _ContactBusiness.ListFavoriteContacts());
      }
      catch
      {
        return StatusCode((int)HttpStatusCode.InternalServerError);
      }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllContacts()
    {
      try
      {
        return Ok(await _ContactBusiness.ListAllContacts());
      }
      catch
      {
        return StatusCode((int)HttpStatusCode.InternalServerError);
      }
    }

    [HttpGet("exists/{id}")]
    public async Task<IActionResult> Exists([FromRoute] int id)
    {
      try
      {
        return Ok(await _ContactBusiness.Exists(id));
      }
      catch
      {
        return StatusCode((int)HttpStatusCode.InternalServerError);
      }
    }
  }
}