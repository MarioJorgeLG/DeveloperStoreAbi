using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class ProductRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<Product> _products;

        public ProductRepository(DbContext context)
        {
            _context = context;
            _products = context.Set<Product>();  
        }
           
        public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(string category)
        {
            return await _products
                .Where(p => p.Category == category)
                .ToListAsync();
        }


        public async Task<List<Product>> GetAllAsync() =>
            await _products.ToListAsync();

        public async Task<Product> GetByIdAsync(string id)
        {
            if (int.TryParse(id, out int intId))
            {
                return await _products.FirstOrDefaultAsync(p => p.Id == intId);
            }

            return null; 
        }

        public async Task AddAsync(Product product) =>
            await _products.AddAsync(product);

        public async Task UpdateAsync(Product product) =>
            _products.Update(product);

        public async Task DeleteAsync(string id)
        {
            var product = await _products.FindAsync(id);
            if (product != null)
            {
                _products.Remove(product);
            }
        }
    }
}
