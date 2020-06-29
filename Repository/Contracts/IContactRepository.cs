using Contacts.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contacts.Repository
{
  public interface IContactRepository : IRepository<Contact>
  {
    Task<IEnumerable<Contact>> Select(bool onlyFavorites = false);
  }
}
