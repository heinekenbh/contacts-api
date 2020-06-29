using Contacts.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contacts.Repository
{
  public interface IContactTypeRepository<T> : IRepository<T>
  {
    Task<IEnumerable<T>> Select(Contact contact);

    Task<T> Select(T obj);
  }
}
