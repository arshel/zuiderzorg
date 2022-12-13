using Microsoft.EntityFrameworkCore;

namespace zuiderzorg.Models
{
    public class CategoryContext :  DbContext
    {
        public DbSet<Product>? Products { get; set; }
        public DbSet<Category>? Categories { get; set; }

        WebApplicationBuilder builder = WebApplication.CreateBuilder();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
    
    

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasKey(e=>e.CategoryId);
            modelBuilder.Entity<Product>().HasKey(e=>new {e.ParentCategoryId, e.ProductId});
            modelBuilder.Entity<Product>().HasOne(d => d.Category).WithMany(e=>e.Products).HasForeignKey(d=>d.ParentCategoryId);
        }
    }
}
public class Category {
        public Guid? CategoryId { get; set; }
        public string? Name { get; set; }
        public IEnumerable<Product>? Products { get; set; }
    }

public class Product
{
    public Guid? ProductId { get; set; }
    public Guid? ParentCategoryId { get; set; }
    public string? Name { get; set; }
    public decimal? Price { get; set; }
    public string? Description { get; set; }
    public Category? Category { get; set; }
}