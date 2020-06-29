using Contacts.Database;
using Contacts.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.Repository
{
  public class PhoneRepository : BaseRepository<Phone>, IContactTypeRepository<Phone>
  {
    public PhoneRepository(AppDbContext context) : base(context)
    {

    }

    public async Task<Phone> Select(int id)
    {
      return await _Context.Phones
        .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Phone> Select(Phone phone)
    {
      return await _Context.Phones
        .FirstOrDefaultAsync(p => p.Id == phone.Id || p.PhoneNumber == phone.PhoneNumber);
    }

    public async Task<IEnumerable<Phone>> Select(Contact contact)
    {
      return await _Context.Phones
          .Where(p => p.ContactId == contact.Id)
          .ToListAsync();
    }
  }
}
