using Contacts.Database;
using Contacts.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.Repository
{
  public class EmailRepository : BaseRepository<Email>, IContactTypeRepository<Email>
  {
    public EmailRepository(AppDbContext context) : base(context)
    {

    }

    public async Task<Email> Select(int id)
    {
      return await _Context.Emails
        .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<Email> Select(Email email)
    {
      return await _Context.Emails
        .FirstOrDefaultAsync(e => e.Id == email.Id || e.EmailAddress == email.EmailAddress);
    }

    public async Task<IEnumerable<Email>> Select(Contact contact)
    {
      return await _Context.Emails
          .Where(p => p.ContactId == contact.Id)
          .ToListAsync();
    }
  }
}
