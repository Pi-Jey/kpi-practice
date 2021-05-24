using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PizzaProject.Core.Pizza;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaProject.Onion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPizzaService _pizzaService;

        public PizzaController(
            IMapper mapper,
            IPizzaService pizzaService)
        {
            _mapper = mapper;
            _pizzaService = pizzaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var pizzas = await _pizzaService.GetAsync();
            return Ok(_mapper.Map<List<PizzaContract.Pizza>>(pizzas));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var cafe = await _pizzaService.GetByIdAsync(id);
            return Ok(_mapper.Map<List<PizzaContract.Pizza>>(cafe));
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync(PizzaContract.Pizza _pizza)
        {
            var pizza = _mapper.Map<PizzaProject.Core.Pizza.Pizza>(_pizza);
            var createdPizza = await _pizzaService.AddAsync(pizza) ;
            return Ok(_mapper.Map<PizzaContract.Pizza>(createdPizza));

        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchAsync(int id, string name)
        {
            var cafe = await _pizzaService.UpdateNameAsync(id, name);
            return Ok(_mapper.Map<PizzaContract.Pizza>(cafe));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _pizzaService.RemoveAsync(id);
            return Ok();

        }
    }
}

