using Microsoft.EntityFrameworkCore;
using PizzaProject.Dao.Cafe;

namespace PizzaProject.Dao
{
    public class CafeDbContext : DbContext
    {
        public CafeDbContext(DbContextOptions<CafeDbContext> options) : base(options)
        {

        }

        public DbSet<CafeDto> Cafes { get; set; }
    }
}
