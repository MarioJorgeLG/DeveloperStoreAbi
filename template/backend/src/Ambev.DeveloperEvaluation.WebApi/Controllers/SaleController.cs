using Ambev.DeveloperEvaluation.Application.DTOs;
using Ambev.DeveloperEvaluation.Domain.Models;
using Ambev.DeveloperEvaluation.Infrastructure.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly SaleRepository _repository;
        private readonly IMapper _mapper;

        public SalesController(SaleRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var sales = await _repository.GetAllAsync();
            return Ok(sales);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var sale = await _repository.GetByIdAsync(id);
            if (sale == null) return NotFound();
            return Ok(sale);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SaleDto saleDto)
        {
            var sale = _mapper.Map<Sale>(saleDto);
            await _repository.CreateAsync(sale);
            return CreatedAtAction(nameof(GetById), new { id = sale.Id }, sale);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] SaleDto saleDto)
        {
            var existingSale = await _repository.GetByIdAsync(id);
            if (existingSale == null) return NotFound();

            var updatedSale = _mapper.Map(saleDto, existingSale);
            await _repository.UpdateAsync(id, updatedSale);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var existingSale = await _repository.GetByIdAsync(id);
            if (existingSale == null) return NotFound();

            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
