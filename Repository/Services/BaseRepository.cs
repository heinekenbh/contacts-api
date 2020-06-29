using Contacts.Database;
using System.Threading.Tasks;

namespace Contacts.Repository
{
  public class BaseRepository<T>
  {
    protected readonly AppDbContext _Context;

    public BaseRepository(AppDbContext context)
    {
      _Context = context;
    }

    public virtual async Task<bool> Insert(T obj)
    {
      _Context.Add(obj);
      return await _Context.SaveChangesAsync() > 0;
    }

    public virtual async Task<bool> Update(T obj)
    {
      _Context.Update(obj);
      return await _Context.SaveChangesAsync() > 0;
    }

    public virtual async Task<bool> Delete(T obj)
    {
      _Context.Remove(obj);
      return await _Context.SaveChangesAsync() > 0;
    }
  }
}
