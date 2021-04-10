using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cafe.Model.Cafe
{
    public interface ICafeRepository
    {
        Task<List<Cafe>> GetAsync();
        Task<Cafe> GetByIdAsync(int id);
        Task<Cafe> UpdateNameAsync(Cafe cafe);
        Task RemoveAsync(int id);
        Task<Cafe> AddAsync(Cafe cafe);
    }
}
