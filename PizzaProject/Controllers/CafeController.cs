using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cafe.Model.Cafe;

namespace PizzaProject.Controllers
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
            return Ok(_mapper.Map<List<Cafeshka.Contract.Cafeshka>>(cafes));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var cafe = await _cafeService.GetByIdAsync(id);
            return Ok(_mapper.Map<List<Cafeshka.Contract.Cafeshka>>(cafe));
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync(Cafeshka.Contract.Cafeshka cafeshka)
        {
            var cafe = _mapper.Map<Cafe.Model.Cafe.Cafe>(cafeshka);
            var createdCafe = await _cafeService.AddAsync(cafe);
            return Ok(_mapper.Map<Cafeshka.Contract.Cafeshka>(createdCafe));

        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchAsync(int id, string name)
        {
            var cafe = await _cafeService.UpdateNameAsync(id, name);
            return Ok(_mapper.Map<Cafeshka.Contract.Cafeshka>(cafe));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _cafeService.RemoveAsync(id);
            return Ok();

        }
    }
}

