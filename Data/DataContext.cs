using ContaBill.Models;
using Microsoft.EntityFrameworkCore;

namespace ContaBill.Data
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Movement> movements { get; set; }
  }
}
