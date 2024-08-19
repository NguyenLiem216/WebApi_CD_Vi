using Microsoft.EntityFrameworkCore;

namespace API_Tutorial_ProductManager.Data
{
    public class DContext : DbContext
    {
        public DContext(DbContextOptions options) : base(options) 
        {
            
        }

        #region DbSet
        public DbSet<User> users { get; set; } = null!;
        public DbSet<Product_data> Product_Datas { get; set; } = null!;
        public DbSet<Products_Type> Product_Types { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<Detailed_Orders> Detailed_Orders {  get; set; } = null!;
        public DbSet<RefreshToken> RefreshTokens { get; set; } = null!;
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(e => 
            {
                e.ToTable("Order");
                e.HasKey(od => od.Id_Ord);
                e.Property(od => od.OrdDate).HasDefaultValueSql("now() AT TIME ZONE 'UTC'");
                e.Property(od => od.Receiver).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<Detailed_Orders>(entity => {
                entity.ToTable("Detailed_Orders");
                entity.HasKey(e => new
                {
                    e.Id,
                    e.Id_Ord
                });
                entity.HasOne(e => e.Order)
                .WithMany(e => e.Detailed_Orders)
                .HasForeignKey(e => e.Id_Ord)
                .HasConstraintName("FK_Detail_Orders_Order");


                entity.HasOne(e => e.Products)
                .WithMany(e => e.Detailed_Orders)
                .HasForeignKey(e => e.Id)
                .HasConstraintName("FK_Detail_Orders_Product");
                
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.UserName).IsUnique();
                entity.Property(e => e.FullName).IsRequired().HasMaxLength(150);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(150);
            });
        }
    }
}
