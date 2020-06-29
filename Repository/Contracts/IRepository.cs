using System.Threading.Tasks;

namespace Contacts.Repository
{
  public interface IRepository<T>
  {
    Task<bool> Insert(T obj);

    Task<bool> Update(T obj);

    Task<bool> Delete(T obj);

    Task<T> Select(int id);
  }
}
