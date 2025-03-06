using Ambev.DeveloperEvaluation.Domain.Events;
using Ambev.DeveloperEvaluation.Application.DTOs;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.Application.DTOs
{
    public class SaleDto
    {
        public string? Id { get; set; }
        public string SaleNumber { get; set; } = string.Empty;
        public DateTime SaleDate { get; set; }
        public string Customer { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public string Branch { get; set; } = string.Empty;
        public List<SaleItemDto> Items { get; set; } = new();
        public bool IsCancelled { get; set; } = false;
    }

    public class SaleItemDto
    {
        public string Product { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
