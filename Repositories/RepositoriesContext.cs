using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories;

public class RepositoriesContext:DbContext
{
    public DbSet<Product> Products { get; set; }
    public RepositoriesContext(DbContextOptions<RepositoriesContext> optionsBuilder):base(optionsBuilder)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Product>().HasData(
            new Product(){ProductId=1,ProductName="Computer",Price=20000},
            new Product(){ProductId=2,ProductName="Phone",Price=10000},
            new Product(){ProductId=3,ProductName="Watch",Price=2000}
        );
    }
}
