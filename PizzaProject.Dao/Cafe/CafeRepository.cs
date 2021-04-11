using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PizzaProject.Model.Cafe;

namespace PizzaProject.Dao.Cafe
{
    public class CafeRepository : ICafeRepository
    {
        private readonly IMapper _mapper;
        private readonly CafeDbContext _context;

        public CafeRepository(IMapper mapper, CafeDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Model.Cafe.Cafe> AddAsync(Model.Cafe.Cafe cafe)
        {
            var entity = _mapper.Map<CafeDto>(cafe);
            var result = await _context.AddAsync(entity);
            return _mapper.Map<Model.Cafe.Cafe>(result.Entity);
        }

        public async Task RemoveAsync(int id)
        {
            var entity = await _context.Cafes.FirstOrDefaultAsync(c => c.Id == id);
            _context.Cafes.Remove(entity);
        }

        public async Task<Model.Cafe.Cafe> UpdateNameAsync(Model.Cafe.Cafe cafe)
        {
            var entity = _mapper.Map<CafeDto>(cafe);
            var result = _context.Update(entity);
            return _mapper.Map<Model.Cafe.Cafe>(result.Entity);
        }

        public async Task<List<Model.Cafe.Cafe>> GetAsync()
        {
            var entities = await _context.Cafes.ToListAsync();
            return _mapper.Map<List<Model.Cafe.Cafe>>(entities);
        }

        public async Task<Model.Cafe.Cafe> GetByIdAsync(int id)
        {
            var entity = await _context.Cafes.FirstOrDefaultAsync(c => c.Id == id);
            return _mapper.Map<Model.Cafe.Cafe>(entity);
        }
    }
}
