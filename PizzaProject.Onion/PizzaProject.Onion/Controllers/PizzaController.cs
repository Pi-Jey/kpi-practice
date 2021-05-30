using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PizzaProject.Core.Pizza;
using System.Collections.Generic;
using System.Threading.Tasks;
using PizzaProject.Orchestrators;

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
            var result = _mapper.Map<List<Orchestrators.PizzaContract.Pizza>>(pizzas);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var pizza = await _pizzaService.GetByIdAsync(id);
            var result = _mapper.Map<Orchestrators.PizzaContract.Pizza>(pizza);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync(Orchestrators.PizzaContract.PizzaforCreate pizzaforcreate)
        {
            var pizza = _mapper.Map<PizzaProject.Core.Pizza.Pizza>(pizzaforcreate);
            var createdPizza = await _pizzaService.AddAsync(pizza);
            var result = _mapper.Map<Orchestrators.PizzaContract.Pizza>(createdPizza);
            return Ok(result);

        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchAsync(int id, string name)
        {
            var pizza = await _pizzaService.UpdateNameAsync(id, name);
            var result = _mapper.Map<Orchestrators.PizzaContract.Pizza>(pizza);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _pizzaService.RemoveAsync(id);
            return Ok();

        }
    }
}

