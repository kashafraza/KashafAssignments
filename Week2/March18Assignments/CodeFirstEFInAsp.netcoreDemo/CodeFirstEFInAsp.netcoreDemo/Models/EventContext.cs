using Microsoft.EntityFrameworkCore;

namespace CodeFirstEFInAsp.netcoreDemo.Models
{
    public class EventContext: DbContext
    {
        public EventContext(DbContextOptions dbContextOptions):
            base(dbContextOptions)
        {
            
        }
        public DbSet<Author> authors { set; get; }
        public DbSet<Course> courses { set; get; }

        public DbSet<Student> students { set; get; }

        public DbSet<Author1> authors1 { set; get; }

        public DbSet<Course1> courses1 { set; get; }

        public DbSet<Employee> employees { set; get; }

        public DbSet<UserDetail> userdetails { set; get; }

        public DbSet<Customer> Customers { set; get; }

        public DbSet<Product> Products { set; get; }
    }
}
