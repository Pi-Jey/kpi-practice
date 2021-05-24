using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PizzaProject.Core.Pizza;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaProject.Data.Pizza
{
    public class PizzaRepository : IPizzaRepository
    {
        private readonly IMapper _mapper;
        private readonly PizzaProjectContext _context;

        public PizzaRepository(IMapper mapper, PizzaProjectContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Core.Pizza.Pizza> AddAsync(Core.Pizza.Pizza pizza)
        {
            var entity = _mapper.Map<PizzaDto>(pizza);
            var result = await _context.AddAsync(entity);
            return _mapper.Map<Core.Pizza.Pizza>(result.Entity);
        }

        public async Task RemoveAsync(int id)
        {
            var entity = await _context.Pizzas.FirstOrDefaultAsync(c => c.Id == id);
            _context.Pizzas.Remove(entity);
        }

        public async Task<Core.Pizza.Pizza> UpdateNameAsync(Core.Pizza.Pizza pizza)
        {
            var entity = _mapper.Map<PizzaDto>(pizza);
            var result = _context.Update(entity);
            return _mapper.Map<Core.Pizza.Pizza>(result.Entity);
        }

        public async Task<List<Core.Pizza.Pizza>> GetAsync()
        {
            var entities = await _context.Pizzas.ToListAsync();
            return _mapper.Map<List<Core.Pizza.Pizza>>(entities);
        }

        public async Task<Core.Pizza.Pizza> GetByIdAsync(int id)
        {
            var entity = await _context.Pizzas.FirstOrDefaultAsync(c => c.Id == id);
            return _mapper.Map<Core.Pizza.Pizza>(entity);
        }
    }
}
