using Microsoft.EntityFrameworkCore;

namespace AppRevendedores.Models
{
    public class Context : DbContext
    {
        public Context (DbContextOptions<Context> options) : base(options)
        { }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> categories { get; set; }

        public DbSet<User> users { get; set; }




    }
}
