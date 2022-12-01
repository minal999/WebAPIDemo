using Microsoft.EntityFrameworkCore;
using WebAPIDemo.Models;

namespace WebAPIDemo.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Product> products { get; set; }
        public DbSet<Employee> employees { get; set; }

        public DbSet<Student> students { get; set; }
    }
}
