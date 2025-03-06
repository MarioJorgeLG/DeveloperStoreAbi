using Ambev.DeveloperEvaluation.Application.DTOs;
using Ambev.DeveloperEvaluation.Domain.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Ambev.DeveloperEvaluation.ORM.Repositories;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.WebApi.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;

        public SalesController(ISaleRepository saleRepository, IMapper mapper)
        {
            _saleRepository = saleRepository ?? throw new ArgumentNullException(nameof(saleRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var sales = await _saleRepository.GetAllAsync();
            return Ok(sales);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSaleById(Guid id)
        {
            var sale = await _saleRepository.GetSaleByIdAsync(id);
            if (sale == null) return NotFound();
            
            return Ok(sale);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SaleDto saleDto)
        {
            var sale = _mapper.Map<Sale>(saleDto);
            await _saleRepository.CreateAsync(sale);
            return CreatedAtAction(nameof(GetSaleById), new { id = sale.Id }, sale);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] SaleDto saleDto)
        {
            var existingSale = await _saleRepository.GetSaleByIdAsync(Guid.Parse(id));
            if (existingSale == null) return NotFound();

            var updatedSale = _mapper.Map(saleDto, existingSale);
            await _saleRepository.UpdateAsync(updatedSale);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var existingSale = await _saleRepository.GetSaleByIdAsync(id);
            if (existingSale == null) return NotFound();

            await _saleRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
