using System;
using AutoMapper;
using PizzaProject.Data;
using Microsoft.EntityFrameworkCore;
using PizzaProject.Onion.PizzaContract;

namespace PizzaProject.Test
{
    public class UnitTestHelper
    {
        public static DbContextOptions<PizzaProjectContext> GetUnitTestDbOptions()
        {
            var options = new DbContextOptionsBuilder<PizzaProjectContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            using (var context = new PizzaProjectContext(options))
            {
                SeedData(context);
            }
            return options;
        }

        public static void SeedData(PizzaProjectContext context)
        {
            context.Cafes.Add(new Data.Cafe.CafeDto { Id = 1, Name = "Domino`s", OpenTime = "09:30",CloseTime = "00:00" });
            context.Pizzas.Add(new Data.Pizza.PizzaDto { Id = 1, Name = "Margaryta", Size = 30, Recipe = "Sous 'Domino's', Moccarella" });
            context.SaveChanges();
        }

        public static Mapper CreateMapperProfile()
        {
            var myProfile = new PizzaProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));

            return new Mapper(configuration);
        }
    }
}
