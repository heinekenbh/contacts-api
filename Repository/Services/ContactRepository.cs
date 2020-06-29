using Contacts.Database;
using Contacts.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.Repository
{
  public class ContactRepository : BaseRepository<Contact>, IContactRepository
  {
    public ContactRepository(AppDbContext context) : base(context)
    {

    }

    public override Task<bool> Update(Contact obj)
    {
      _Context.RemoveRange(_Context.Phones.Where(phone => !obj.Phones.Contains(phone)));
      _Context.RemoveRange(_Context.Emails.Where(email => !obj.Emails.Contains(email)));

      return base.Update(obj);
    }

    public async Task<Contact> Select(int id)
    {
      return await _Context.Contacts
        .Include(c => c.Emails)
        .Include(c => c.Phones)
        .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<IEnumerable<Contact>> Select(bool onlyFavorites = false)
    {
      IEnumerable<Contact> contacts = await _Context.Contacts
          .Include(c => c.Emails)
          .Include(c => c.Phones)
          .ToListAsync();

      if (onlyFavorites)
        contacts = contacts.Where(c => c.Favorite);

      return contacts;
    }
  }
}
