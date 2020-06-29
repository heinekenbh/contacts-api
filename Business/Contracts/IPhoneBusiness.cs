using Contacts.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contacts.Business
{
  public interface IPhoneBusiness
  {
    Task<bool> Add(Phone Phone);

    Task<bool> Edit(int id, Phone Phone);

    Task<bool> Del(Phone Phone);

    Task<Phone> Find(int id);

    Task<IEnumerable<Phone>> ListAllPhones(int contactId);

    Task<bool> Exists(int id);

    Task<bool> Exists(string phoneNumber);
  }
}
