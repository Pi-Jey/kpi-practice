using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PizzaProject.Core.Cafe;
using System.Collections.Generic;
using System.Threading.Tasks;

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
            return Ok(_mapper.Map<List<CafeContract.Cafe>>(cafes));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var cafe = await _cafeService.GetByIdAsync(id);
            return Ok(_mapper.Map<List<CafeContract.Cafe>>(cafe));
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync(CafeContract.Cafe _cafe)
        {
            var cafe = _mapper.Map<PizzaProject.Core.Cafe.Cafe>(_cafe);
            var createdCafe = await _cafeService.AddAsync(cafe);
            return Ok(_mapper.Map<CafeContract.Cafe>(createdCafe));

        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchAsync(int id, string name)
        {
            var cafe = await _cafeService.UpdateNameAsync(id, name);
            return Ok(_mapper.Map<CafeContract.Cafe>(cafe));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _cafeService.RemoveAsync(id);
            return Ok();

        }
    }
}
