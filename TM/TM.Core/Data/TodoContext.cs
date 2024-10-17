using Microsoft.EntityFrameworkCore;
using TM.Core.Entity;

namespace TM.Core.Data
{
    public class TodoContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDb)\MSSQLLocalDB;Database=TM_DB;TrustServerCertificate=True;Trusted_Connection=True;");
        }
    }
}
