using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PizzaProject.Core.Cafe;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaProject.Data.Cafe
{
    public class CafeRepository : ICafeRepository
    {
        private readonly IMapper _mapper;
        private readonly PizzaProjectContext _context;

        public CafeRepository(IMapper mapper, PizzaProjectContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Core.Cafe.Cafe> AddAsync(Core.Cafe.Cafe cafe)
        {
            var entity = _mapper.Map<CafeDto>(cafe);
            var result = await _context.AddAsync(entity);
            return _mapper.Map<Core.Cafe.Cafe>(result.Entity);
        }

        public async Task RemoveAsync(int id)
        {
            var entity = await _context.Cafes.FirstOrDefaultAsync(c => c.Id == id);
            _context.Cafes.Remove(entity);
        }

        public async Task<Core.Cafe.Cafe> UpdateNameAsync(Core.Cafe.Cafe cafe)
        {
            var entity = _mapper.Map<CafeDto>(cafe);
            var result = _context.Update(entity);
            return _mapper.Map<Core.Cafe.Cafe>(result.Entity);
        }

        public async Task<List<Core.Cafe.Cafe>> GetAsync()
        {
            var entities = await _context.Cafes.ToListAsync();
            return _mapper.Map<List<Core.Cafe.Cafe>>(entities);
        }

        public async Task<Core.Cafe.Cafe> GetByIdAsync(int id)
        {
            var entity = await _context.Cafes.FirstOrDefaultAsync(c => c.Id == id);
            return _mapper.Map<Core.Cafe.Cafe>(entity);
        }
    }
}
