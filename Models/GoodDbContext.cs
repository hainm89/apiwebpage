using Microsoft.EntityFrameworkCore;

namespace Ass1.Models
{
    public class GoodDbContext : DbContext
    {
        public DbSet<Good> Goods { get; set; }

        public GoodDbContext(DbContextOptions<GoodDbContext> options) : base(options) { }
    }
}
