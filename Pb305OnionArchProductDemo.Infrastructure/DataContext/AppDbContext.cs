using Microsoft.EntityFrameworkCore;
using Pb305OnionArchProductDemo.Domain.Entities;

namespace Pb305OnionArchProductDemo.Infrastructure.DataContext;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
   
    public DbSet<Product> Products { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<ProductTag> ProductTags { get; set; }
    public DbSet<Test> Tests { get; set; }
    public DbSet<TezBazar> TezBazars { get; set; }
}
