using EF_Test.Models.Entity;
using EF_Test.Seeds;
using Microsoft.EntityFrameworkCore;

namespace EF_Test.Contexts
{
    public class ShopContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }

        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(user =>
            {
                user.ToTable("User");
                user.HasKey(p => p.Id);
                user.Property(p => p.email);
            });

            //Seed data
            modelBuilder.ApplyConfiguration(new ProductSeed());
            base.OnModelCreating(modelBuilder);
        }


    }
}
