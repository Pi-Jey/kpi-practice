using Microsoft.EntityFrameworkCore;
using PizzaProject.Data.Cafe;
using PizzaProject.Data.Pizza;

namespace PizzaProject.Data
{
    public class PizzaProjectContext : DbContext
    {
        public PizzaProjectContext(DbContextOptions<PizzaProjectContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<CafeDto> Cafes { get; set; }
        public DbSet<PizzaDto> Pizzas { get; set; }
    }

}
