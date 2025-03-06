using MediatR;
using Ambev.DeveloperEvaluation.Application.DTOs;
using Ambev.DeveloperEvaluation.Application.Queries;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.MediatR.Handlers
{
    // O handler agora implementa IRequestHandler<GetProductsQuery, List<ProductDto>>
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, List<ProductDto>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductsHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            // Chama o repositório para obter os produtos, filtrando pela categoria (se fornecida)
            var products = await _productRepository.GetProductsByCategoryAsync(request.Category);

            // Converte os produtos para DTOs (caso necessário)
            var productDtos = products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name
            }).ToList();

            return productDtos;
        }
    }
}
