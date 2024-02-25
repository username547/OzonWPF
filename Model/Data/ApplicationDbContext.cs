using Microsoft.EntityFrameworkCore;

namespace Ozon.Model.Data
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<User> Users {  get; set; }

        public ApplicationDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=ANDREW;Initial Catalog=Ozon;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
    }
}
