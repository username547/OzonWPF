using Microsoft.EntityFrameworkCore;
using Ozon.Model;

namespace Ozon.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<SellerModel> Sellers { get; set; }
        public DbSet<EmployeeModel> Employees { get; set; }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<ShopModel> Shops { get; set; }
        public DbSet<PickupPointModel> PickPoints { get; set; }
        public DbSet<RoleModel> Roles { get; set; }
        public DbSet<CartModel> Carts { get; set; }
        public DbSet<CartItemModel> CartItems { get; set; }
        public DbSet<OrderModel> Orders { get; set; }
        public DbSet<OrderItemModel> OrderItems { get; set; }
        public DbSet<StatusModel> Status { get; set; }
        public DbSet<IssuanceModel> Issuances { get; set; }

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
