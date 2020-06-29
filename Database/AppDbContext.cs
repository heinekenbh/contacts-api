using Contacts.Models;
using Microsoft.EntityFrameworkCore;

namespace Contacts.Database
{
  public class AppDbContext : DbContext
  {
    public DbSet<Contact> Contacts { get; set; }

    public DbSet<Phone> Phones { get; set; }

    public DbSet<Email> Emails { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
  }
}
