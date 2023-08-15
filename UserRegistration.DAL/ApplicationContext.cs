using Microsoft.EntityFrameworkCore;
using UserRegistration.DAL.Models;

namespace UserRegistration.DAL
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<UserModel> Users { get; set; }
    }
}
