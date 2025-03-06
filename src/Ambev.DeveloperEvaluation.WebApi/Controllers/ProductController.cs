using Microsoft.AspNetCore.Mvc;
using MediatR;
using Ambev.DeveloperEvaluation.ORM.Repositories;
using Ambev.DeveloperEvaluation.Application.Queries;

namespace Ambev.DeveloperEvaluation.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var result = await _mediator.Send(new GetProductsQuery());
            return Ok(result);
        }
    }
}