using Microsoft.EntityFrameworkCore;

namespace FakeStoreApp.entities
{
    public class FakeStoreDbContext : DbContext
    {
        public FakeStoreDbContext(DbContextOptions options) : base(options) { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().ToTable("Products");
        }
    }
}
