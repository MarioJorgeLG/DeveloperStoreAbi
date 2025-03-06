using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface ISaleRepository
    // {
    //     Task<IEnumerable<Sale>> GetAllSalesAsync();
    //     Task<IEnumerable<Sale>> GetAllAsync();
    //     Task<Sale> GetSaleByIdAsync(Guid id); 
    //     Task AddSaleAsync(Sale sale); 
    //     Task UpdateSaleAsync(Sale sale); 
    //     Task DeleteSaleAsync(Guid id);
    //     Task CreateAsync(Sale sale);
    //     Task UpdateAsync(Sale sale);
    //     Task DeleteAsync(Guid id);
    // }
    {
        Task<IEnumerable<Sale>> GetAllAsync();
        Task<Sale> GetSaleByIdAsync(Guid id);
        Task CreateAsync(Sale sale);
        Task UpdateAsync(Sale sale);
        Task DeleteAsync(Guid id);
    }
}
