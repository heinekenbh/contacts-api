using Contacts.Models;
using Contacts.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contacts.Business
{
  public class PhoneBusiness : IPhoneBusiness
  {
    private readonly IContactTypeRepository<Phone> _PhoneRepository;
    private readonly IContactRepository _ContactRepository;

    public PhoneBusiness(IContactTypeRepository<Phone> phoneRepository, IContactRepository contactReposiory)
    {
      _PhoneRepository = phoneRepository;
      _ContactRepository = contactReposiory;
    }

    public async Task<bool> Add(Phone phone)
    {
      return await _PhoneRepository.Insert(phone);
    }

    public async Task<bool> Edit(int id, Phone phone)
    {
      return await _PhoneRepository.Update(phone);
    }

    public async Task<bool> Del(Phone phone)
    {
      return await _PhoneRepository.Delete(phone);
    }

    public async Task<Phone> Find(int id)
    {
      return await _PhoneRepository.Select(id);
    }

    public async Task<IEnumerable<Phone>> ListAllPhones(int contactId)
    {
      return await _PhoneRepository.Select(await _ContactRepository.Select(contactId));
    }

    public async Task<bool> Exists(int id)
    {
      return await _PhoneRepository.Select(new Phone()
      {
        Id = id
      }) != null;
    }

    public async Task<bool> Exists(string phoneNumber)
    {
      return await _PhoneRepository.Select(new Phone()
      {
        PhoneNumber = phoneNumber
      }) != null;
    }
  }
}
