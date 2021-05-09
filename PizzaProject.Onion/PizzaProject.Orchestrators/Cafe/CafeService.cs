using PizzaProject.Core.Cafe;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace PizzaProject.Orchestrators.Cafe
{
    public class CafeService : ICafeService
    {
        private readonly ICafeRepository _cafeRepository;

        public CafeService(ICafeRepository cafeRepository)
        {
            _cafeRepository = cafeRepository;
        }
        public async Task<Core.Cafe.Cafe> AddAsync(Core.Cafe.Cafe cafe)
        {
            return await _cafeRepository.AddAsync(cafe);
        }

        public async Task<List<Core.Cafe.Cafe>> GetAsync()
        {
            return await _cafeRepository.GetAsync();
        }

        public async Task<Core.Cafe.Cafe> GetByIdAsync(int id)
        {
            if (id <= 0)
                throw new ValidationException();

            return await _cafeRepository.GetByIdAsync(id);
        }

        public async Task RemoveAsync(int id)
        {
            var cafe = await _cafeRepository.GetByIdAsync(id);

            if (cafe == null)
                throw new ArgumentOutOfRangeException();

            await _cafeRepository.RemoveAsync(cafe.Id);
        }

        public async Task<Core.Cafe.Cafe> UpdateNameAsync(int id, string name)
        {
            var cafe = await _cafeRepository.GetByIdAsync(id);

            if (cafe == null)
                throw new ArgumentOutOfRangeException();

            if (name == "")
                throw new ArgumentOutOfRangeException();

            cafe.Name = name;
            await _cafeRepository.UpdateNameAsync(cafe);
            return cafe;
        }
    }
}
