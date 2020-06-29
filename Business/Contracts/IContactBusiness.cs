using Contacts.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contacts.Business
{
  public interface IContactBusiness
  {
    Task<bool> Add(Contact contact);

    Task<bool> Edit(int id, Contact contact);

    Task<bool> Del(Contact contact);

    Task<Contact> Find(int id);

    Task<IEnumerable<Contact>> ListFavoriteContacts();

    Task<IEnumerable<Contact>> ListAllContacts();

    Task<bool> Exists(int id);
  }
}
