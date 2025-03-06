using MediatR;
using System.Collections.Generic;
using Ambev.DeveloperEvaluation.Application.DTOs;

namespace Ambev.DeveloperEvaluation.Application.Queries
{
    public class GetProductsQuery : IRequest<List<ProductDto>>
    {
        public string Category { get; set; }
    }
}