using Contacts.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contacts.Business
{
  public interface IEmailBusiness
  {
    Task<bool> Add(Email Email);

    Task<bool> Edit(int id, Email Email);

    Task<bool> Del(Email Email);

    Task<Email> Find(int id);

    Task<IEnumerable<Email>> ListAllEmails(int contactId);

    Task<bool> Exists(int id);

    Task<bool> Exists(string emailAddress);
  }
}
