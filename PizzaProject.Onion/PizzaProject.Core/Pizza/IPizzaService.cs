using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaProject.Core.Pizza
{
    public interface IPizzaService
    {
        Task<List<Pizza>> GetAsync();
        Task<Pizza> GetByIdAsync(int id);
        Task<Pizza> UpdateNameAsync(int id, string name);
        Task RemoveAsync(int id);
        Task<Pizza> AddAsync(Pizza cafe);
    }
}
