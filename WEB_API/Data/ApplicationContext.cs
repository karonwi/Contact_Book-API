using API.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Model;

namespace API.Data
{
    public class ApplicationContext : IdentityDbContext<UserContact>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
        public DbSet<Address> Addresses { get; set; }
       
    }
}
