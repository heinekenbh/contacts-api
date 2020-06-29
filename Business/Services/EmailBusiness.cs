using Contacts.Models;
using Contacts.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contacts.Business
{
  public class EmailBusiness : IEmailBusiness
  {
    private readonly IContactTypeRepository<Email> _EmailRepository;
    private readonly IContactRepository _ContactRepository;

    public EmailBusiness(IContactTypeRepository<Email> emailRepository, IContactRepository contactReposiory)
    {
      _EmailRepository = emailRepository;
      _ContactRepository = contactReposiory;
    }

    public async Task<bool> Add(Email email)
    {
      return await _EmailRepository.Insert(email);
    }

    public async Task<bool> Edit(int id, Email email)
    {
      return await _EmailRepository.Update(email);
    }

    public async Task<bool> Del(Email email)
    {
      return await _EmailRepository.Delete(email);
    }

    public async Task<Email> Find(int id)
    {
      return await _EmailRepository.Select(id);
    }

    public async Task<IEnumerable<Email>> ListAllEmails(int contactId)
    {
      return await _EmailRepository.Select(await _ContactRepository.Select(contactId));
    }

    public async Task<bool> Exists(int id)
    {
      return await _EmailRepository.Select(new Email()
      {
        Id = id
      }) != null;
    }

    public async Task<bool> Exists(string emailAddress)
    {
      return await _EmailRepository.Select(new Email()
      {
        EmailAddress = emailAddress
      }) != null;
    }
  }
}
