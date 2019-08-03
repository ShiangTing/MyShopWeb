using System.Data.Entity;
using CoreMode.Model;
using MyShopWeb.Models;


namespace MyshopWebDataAccess.SQL
{
    public class DataContext :DbContext
    {
        
        public DataContext()
            : base("DefaultConnection")
        {


        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }


        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Cart> Carts { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductCategory.Mapping());
        }
    }

}
