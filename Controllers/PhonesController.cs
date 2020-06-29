using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Contacts.Database;
using Contacts.Models;
using System.Net;
using MySql.Data.MySqlClient;
using Contacts.Repository;
using Contacts.Business;

namespace Contacts.Controllers
{
  [Route("api/v1/phones"), ApiController]
  public class PhonesController : ControllerBase
  {
    private readonly IPhoneBusiness _PhoneBusiness;

    public PhonesController(IPhoneBusiness phoneBusiness)
    {
      _PhoneBusiness = phoneBusiness;
    }

    [HttpPost]
    public async Task<IActionResult> PostPhone([FromBody] Phone phone)
    {
      try
      {
        if (!ModelState.IsValid)
          return BadRequest(ModelState);

        await _PhoneBusiness.Add(phone);

        return CreatedAtAction("GetPhone", new { id = phone.Id }, phone);
      }
      catch (DbUpdateException ex) when (ex.InnerException is MySqlException sqlException && sqlException.Number == 1062)
      {
        return BadRequest(new
        {
          fullName = new List<string>() { "A phone with this number already exists." }
        });
      }
      catch
      {
        return StatusCode((int)HttpStatusCode.InternalServerError);
      }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutPhone([FromRoute] int id, [FromBody] Phone phone)
    {
      try
      {
        if (!ModelState.IsValid)
          return BadRequest(ModelState);

        if (id != phone.Id)
          return BadRequest();

        await _PhoneBusiness.Edit(id, phone);

        return NoContent();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!await _PhoneBusiness.Exists(id))
          return NotFound();
        else
          throw;
      }
      catch (DbUpdateException ex) when (ex.InnerException is MySqlException sqlException && sqlException.Number == 1062)
      {
        return BadRequest(new
        {
          fullName = new List<string>() { "A phone with this number already exists." }
        });
      }
      catch
      {
        return StatusCode((int)HttpStatusCode.InternalServerError);
      }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePhone([FromRoute] int id)
    {
      try
      {
        if (!ModelState.IsValid)
          return BadRequest(ModelState);

        var phone = await _PhoneBusiness.Find(id);

        if (phone == null)
          return NotFound();

        await _PhoneBusiness.Del(phone);

        return Ok(phone);
      }
      catch
      {
        return StatusCode((int)HttpStatusCode.InternalServerError);
      }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPhone([FromRoute] int id)
    {
      try
      {
        if (!ModelState.IsValid)
          return BadRequest(ModelState);

        var phone = await _PhoneBusiness.Find(id);

        if (phone == null)
          return NotFound();

        return Ok(phone);
      }
      catch
      {
        return StatusCode((int)HttpStatusCode.InternalServerError);
      }
    }

    [HttpGet("list/{contactId}")]
    public async Task<IActionResult> GetAllPhones([FromRoute] int contactId)
    {
      try
      {
        return Ok(await _PhoneBusiness.ListAllPhones(contactId));
      }
      catch
      {
        return StatusCode((int)HttpStatusCode.InternalServerError);
      }
    }

    [HttpGet("exists/{phoneNumber}")]
    public async Task<IActionResult> Exists([FromRoute] string phoneNumber)
    {
      try
      {
        return Ok(await _PhoneBusiness.Exists(phoneNumber));
      }
      catch
      {
        return StatusCode((int)HttpStatusCode.InternalServerError);
      }
    }
  }
}