using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Contacts.Database;
using Contacts.Models;
using System.Net;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Contacts.Repository;
using Contacts.Business;

namespace Contacts.Controllers
{
  [Route("api/v1/emails"), ApiController]
  public class EmailsController : ControllerBase
  {
    private readonly IEmailBusiness _EmailBusiness;

    public EmailsController(IEmailBusiness emailBusiness)
    {
      _EmailBusiness = emailBusiness;
    }

    [HttpPost]
    public async Task<IActionResult> PostEmail([FromBody] Email email)
    {
      try
      {
        if (!ModelState.IsValid)
          return BadRequest(ModelState);

        await _EmailBusiness.Add(email);

        return CreatedAtAction("GetEmail", new { id = email.Id }, email);
      }
      catch (DbUpdateException ex) when (ex.InnerException is MySqlException sqlException && sqlException.Number == 1062)
      {
        return BadRequest(new
        {
          fullName = new List<string>() { "An e-mail with this address already exists." }
        });
      }
      catch
      {
        return StatusCode((int)HttpStatusCode.InternalServerError);
      }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutEmail([FromRoute] int id, [FromBody] Email email)
    {
      try
      {
        if (!ModelState.IsValid)
          return BadRequest(ModelState);

        if (id != email.Id)
          return BadRequest();

        await _EmailBusiness.Edit(id, email);

        return NoContent();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!await _EmailBusiness.Exists(id))
          return NotFound();
        else
          throw;
      }
      catch (DbUpdateException ex) when (ex.InnerException is MySqlException sqlException && sqlException.Number == 1062)
      {
        return BadRequest(new
        {
          fullName = new List<string>() { "An e-mail with this address already exists." }
        });
      }
      catch
      {
        return StatusCode((int)HttpStatusCode.InternalServerError);
      }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmail([FromRoute] int id)
    {
      try
      {
        if (!ModelState.IsValid)
          return BadRequest(ModelState);

        var email = await _EmailBusiness.Find(id);

        if (email == null)
          return NotFound();

        await _EmailBusiness.Del(email);

        return Ok(email);
      }
      catch
      {
        return StatusCode((int)HttpStatusCode.InternalServerError);
      }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetEmail([FromRoute] int id)
    {
      try
      {
        if (!ModelState.IsValid)
          return BadRequest(ModelState);

        var email = await _EmailBusiness.Find(id);

        if (email == null)
          return NotFound();

        return Ok(email);
      }
      catch
      {
        return StatusCode((int)HttpStatusCode.InternalServerError);
      }
    }

    [HttpGet("list/{contactId}")]
    public async Task<IActionResult> GetAllEmails([FromRoute] int contactId)
    {
      try
      {
        return Ok(await _EmailBusiness.ListAllEmails(contactId));
      }
      catch
      {
        return StatusCode((int)HttpStatusCode.InternalServerError);
      }
    }

    [HttpGet("exists/{emailAddress}")]
    public async Task<IActionResult> Exists([FromRoute] string emailAddress)
    {
      try
      {
        return Ok(await _EmailBusiness.Exists(emailAddress));
      }
      catch
      {
        return StatusCode((int)HttpStatusCode.InternalServerError);
      }
    }
  }
}