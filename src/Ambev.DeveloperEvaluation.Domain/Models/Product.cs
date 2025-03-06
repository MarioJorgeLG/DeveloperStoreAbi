using Ambev.DeveloperEvaluation.Domain.Models;
namespace Ambev.DeveloperEvaluation.Domain.Models
{
    public class Product
    {
        public string Id { get; set; } = string.Empty;
        
        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }
    }
}
