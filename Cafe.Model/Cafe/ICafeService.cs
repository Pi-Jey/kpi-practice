using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cafe.Model.Cafe
{
    public interface ICafeService
    {
        Task<List<Cafe>> GetAsync();
        Task<Cafe> GetByIdAsync(int id);
        Task<Cafe> UpdateNameAsync(int id, string name);
        Task RemoveAsync(int id);
        Task<Cafe> AddAsync(Cafe cafe);
    }
}
