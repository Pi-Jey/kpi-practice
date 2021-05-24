using PizzaProject.Core.Pizza;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace PizzaProject.Orchestrators.Pizza
{
    public class PizzaService : IPizzaService
    {
        private readonly IPizzaRepository _pizzaRepository;

        public PizzaService(IPizzaRepository pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
        }
        public async Task<Core.Pizza.Pizza> AddAsync(Core.Pizza.Pizza pizza)
        {
            return await _pizzaRepository.AddAsync(pizza);
        }

        public async Task<List<Core.Pizza.Pizza>> GetAsync()
        {
            return await _pizzaRepository.GetAsync();
        }

        public async Task<Core.Pizza.Pizza> GetByIdAsync(int id)
        {
            if (id <= 0)
                throw new ValidationException();

            return await _pizzaRepository.GetByIdAsync(id);
        }

        public async Task RemoveAsync(int id)
        {
            var pizza = await _pizzaRepository.GetByIdAsync(id);

            if (pizza == null)
                throw new ArgumentOutOfRangeException();

            await _pizzaRepository.RemoveAsync(pizza.Id);
        }

        public async Task<Core.Pizza.Pizza> UpdateNameAsync(int id, string name)
        {
            var pizza = await _pizzaRepository.GetByIdAsync(id);

            if (pizza == null)
                throw new ArgumentOutOfRangeException();

            if (string.IsNullOrEmpty(name))
                throw new ArgumentOutOfRangeException();

            pizza.Name = name;
            await _pizzaRepository.UpdateNameAsync(pizza);
            return pizza;
        }
    }
}
