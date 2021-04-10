using Microsoft.EntityFrameworkCore;
using Cafe.Dao.Cafe;

namespace Cafe.Dao
{
    public class CafeDbContext: DbContext
    {
        public CafeDbContext(DbContextOptions<CafeDbContext> options) : base(options)
        {
            
        }

        public DbSet<CafeDto> Cafes { get; set; }
    }
}
