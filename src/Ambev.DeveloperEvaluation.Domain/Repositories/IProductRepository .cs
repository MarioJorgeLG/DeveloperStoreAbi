using System.Collections.Generic;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsByCategoryAsync(string category);
        Task<IEnumerable<Product>> GetAllProductsAsync();
    }
}
