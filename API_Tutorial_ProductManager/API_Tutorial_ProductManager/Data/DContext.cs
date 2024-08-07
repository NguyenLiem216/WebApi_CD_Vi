using Microsoft.EntityFrameworkCore;

namespace API_Tutorial_ProductManager.Data
{
    public class DContext : DbContext
    {
        public DContext(DbContextOptions options) : base(options) 
        {
            
        }

        #region DbSet
        public DbSet<Product_data> Product_Datas { get; set; } = null!;
        public DbSet<Products_Type> Product_Types { get; set; } = null!;
        #endregion
    }
}
