using Ambev.DeveloperEvaluation.Domain.Models;
using MongoDB.Driver;

public class SaleRepository : ISaleRepository
{
    private readonly IMongoCollection<Sale> _sales;

    public SaleRepository(IMongoDbContext context)
    {
        _sales = context.GetCollection<Sale>("Sales");
    }

    public async Task<List<Sale>> GetAllAsync() => await _sales.Find(_ => true).ToListAsync();
    public async Task<Sale?> GetByIdAsync(Guid id) => await _sales.Find(s => s.Id == id).FirstOrDefaultAsync();
    public async Task CreateAsync(Sale sale) => await _sales.InsertOneAsync(sale);
    public async Task UpdateAsync(Sale sale) => await _sales.ReplaceOneAsync(s => s.Id == sale.Id, sale);
    public async Task DeleteAsync(Guid id) => await _sales.DeleteOneAsync(s => s.Id == id);
}
