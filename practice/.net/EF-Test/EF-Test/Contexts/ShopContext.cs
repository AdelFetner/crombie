using EF_Test.Models;
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
            ModelBuilder.Entity<User>(p =>
            {
                p.ToTable("User");
                p.HasKey(p => p.Id);
                p.Property(p => p.email);
                p.
        }
    }
}
