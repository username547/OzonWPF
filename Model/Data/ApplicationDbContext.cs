using Microsoft.EntityFrameworkCore;

namespace Ozon.Model.Data
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<UserModel> Users {  get; set; }
        public DbSet<SellerModel> Sellers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShopModel> Shops { get; set; }
        public DbSet<PickupPoint> PickPoints { get; set; }
        public DbSet<RoleModel> Roles { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Issuance> Issuances { get; set; }

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
