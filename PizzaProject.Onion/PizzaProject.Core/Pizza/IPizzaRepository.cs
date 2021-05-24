using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaProject.Core.Pizza
{
    public interface IPizzaRepository
    {
        Task<List<Pizza>> GetAsync();
        Task<Pizza> GetByIdAsync(int id);
        Task<Pizza> UpdateNameAsync(Pizza cafe);
        Task RemoveAsync(int id);
        Task<Pizza> AddAsync(Pizza cafe);
    }
}
