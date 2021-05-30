using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PizzaProject.Core.Cafe;
using System.Collections.Generic;
using System.Threading.Tasks;
using PizzaProject.Orchestrators;

namespace PizzaProject.Onion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CafeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICafeService _cafeService;

        public CafeController(
            IMapper mapper,
            ICafeService cafeService)
        {
            _mapper = mapper;
            _cafeService = cafeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var cafes = await _cafeService.GetAsync();
            var result = _mapper.Map<List<Orchestrators.CafeContract.Cafe>>(cafes);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var cafe = await _cafeService.GetByIdAsync(id);
            var result = _mapper.Map<Orchestrators.CafeContract.Cafe>(cafe);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync(Orchestrators.CafeContract.CafeforCreate cafeforcreate)
        {
            var cafe = _mapper.Map<PizzaProject.Core.Cafe.Cafe>(cafeforcreate);
            var createdCafe = await _cafeService.AddAsync(cafe);
            var result = _mapper.Map<Orchestrators.CafeContract.Cafe>(createdCafe);
            return Ok(result);

        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchAsync(int id, string name)
        {
            var cafe = await _cafeService.UpdateNameAsync(id, name);
            var result = _mapper.Map<Orchestrators.CafeContract.Cafe>(cafe);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _cafeService.RemoveAsync(id);
            return Ok();

        }
    }
}
