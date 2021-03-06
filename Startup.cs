using Contacts.Business;
using Contacts.Database;
using Contacts.Models;
using Contacts.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Contacts
{
  public class Startup
  {
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
      _ = services.AddDbContext<AppDbContext>(options =>
            options.UseMySql(Configuration.GetConnectionString("DbConnection")));

      services.AddCors();

      services.AddScoped<IContactRepository, ContactRepository>();
      services.AddScoped<IContactBusiness, ContactBusiness>();

      services.AddScoped<IContactTypeRepository<Phone>, PhoneRepository>();
      services.AddScoped<IPhoneBusiness, PhoneBusiness>();

      services.AddScoped<IContactTypeRepository<Email>, EmailRepository>();
      services.AddScoped<IEmailBusiness, EmailBusiness>();

      services.AddControllers();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
        app.UseDeveloperExceptionPage();

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
