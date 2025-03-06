using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ambev.DeveloperEvaluation.ORM.Data;
using Ambev.DeveloperEvaluation.Domain.Models;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly ApplicationDbContext _context;

        public SaleRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Sale>> GetAllAsync()
        {
            return await _context.Sales.ToListAsync();
        }

        public async Task<Sale> GetSaleByIdAsync(Guid id) 
        {
            return await _context.Sales.FindAsync(id);
        }

        public async Task CreateAsync(Sale sale)
        {
            await _context.Sales.AddAsync(sale);
            await _context.SaveChangesAsync();
        }

        public async Task AddSaleAsync(Sale sale)
        {
            await _context.Sales.AddAsync(sale);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Sale sale)
        {
            _context.Sales.Update(sale);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var sale = await _context.Sales.FindAsync(id);
            if (sale != null)
            {
                _context.Sales.Remove(sale);
                await _context.SaveChangesAsync();
            }
        }

    }
}
