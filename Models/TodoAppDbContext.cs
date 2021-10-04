
using Microsoft.EntityFrameworkCore;

namespace PlannerAPI2.Models
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions options) : base(options)
        {
        }

        protected TodoDbContext()
        {
        }
        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<User> Users { get; set; }
    }
}

