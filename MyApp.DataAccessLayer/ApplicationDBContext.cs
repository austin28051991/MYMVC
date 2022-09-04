using Microsoft.EntityFrameworkCore;
using MyApp.Models;

namespace MyApp.DataAccessLayer
{
    public class ApplicationDBContext :DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options)
        {

        }
        public DbSet<Category> categories { get; set; }

        public DbSet<Product> products { get; set; }
    }
}
