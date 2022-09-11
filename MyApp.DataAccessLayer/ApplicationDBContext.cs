using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyApp.Models;

namespace MyApp.DataAccessLayer
{
    public class ApplicationDBContext :IdentityDbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options)
        {

        }
        public DbSet<Category> categories { get; set; }

        public DbSet<Product> products { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}
