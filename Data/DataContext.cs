using ContaBill.Models;
using Microsoft.EntityFrameworkCore;

namespace ContaBill.Data
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Category>().HasData(
        new Category { Title = "Entrada" },
        new Category { Title = "Saída" }
      );
    }

    public DbSet<Movement> Movements { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Type> Types { get; set; }
  }
}
