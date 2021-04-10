using Cafe.Model.Cafe;
using Cafe.Model.Exception;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cafe.Orchestrators.Cafe
{
    public class CafeService : ICafeService
    {
        private readonly ICafeRepository _cafeRepository;

        public CafeService(ICafeRepository cafeRepository)
        {
            _cafeRepository = cafeRepository;
        }
        public async Task<Model.Cafe.Cafe> AddAsync(Model.Cafe.Cafe cafe)
        {
            return await _cafeRepository.AddAsync(cafe);
        }

        public async Task<List<Model.Cafe.Cafe>> GetAsync()
        {
            return await _cafeRepository.GetAsync();
        }

        public async Task<Model.Cafe.Cafe> GetByIdAsync(int id)
        {
            if (id <= 0)
                throw new ValidationException();

            return await _cafeRepository.GetByIdAsync(id);
        }

        public async Task RemoveAsync(int id)
        {
            var cafe = await _cafeRepository.GetByIdAsync(id);

            if (cafe == null)
                throw new ValidationException(message: $"Cafe not found, cafeid = {id}");

            await _cafeRepository.RemoveAsync(cafe.Id);
        }

        public async Task<Model.Cafe.Cafe> UpdateNameAsync(int id, string name)
        {
            var cafe = await _cafeRepository.GetByIdAsync(id);

            if (cafe == null)
                throw new ValidationException(message:$"Cafe not found, cafeid = {id}");

            if (name == "")
                throw new ValidationException(message:"invalid name");

            cafe.Name = name;
            await _cafeRepository.UpdateNameAsync(cafe);
            return cafe;
        }
    }

  
}
