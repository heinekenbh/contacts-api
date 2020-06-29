using Contacts.Models;
using Contacts.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contacts.Business
{
  public class ContactBusiness : IContactBusiness
  {
    private readonly IContactRepository _ContactRepository;

    public ContactBusiness(IContactRepository contactRepository)
    {
      _ContactRepository = contactRepository;
    }

    public async Task<bool> Add(Contact contact)
    {
      return await _ContactRepository.Insert(contact);
    }

    public async Task<bool> Edit(int id, Contact contact)
    {
      return await _ContactRepository.Update(contact);
    }

    public async Task<bool> Del(Contact contact)
    {
      return await _ContactRepository.Delete(contact);
    }

    public async Task<Contact> Find(int id)
    {
      return await _ContactRepository.Select(id);
    }

    public async Task<IEnumerable<Contact>> ListFavoriteContacts()
    {
      return await _ContactRepository.Select(true);
    }

    public async Task<IEnumerable<Contact>> ListAllContacts()
    {
      return await _ContactRepository.Select();
    }

    public async Task<bool> Exists(int id)
    {
      return await _ContactRepository.Select(id) != null;
    }
  }
}
