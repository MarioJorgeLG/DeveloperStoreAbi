using Ambev.DeveloperEvaluation.Domain.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Ambev.DeveloperEvaluation.Infrastructure.Repositories
{
    public class SaleRepository
    {
        private readonly IMongoCollection<Sale> _salesCollection;

        public SaleRepository(IOptions<MongoDbConfig> mongoDbConfig)
        {
            var client = new MongoClient(mongoDbConfig.Value.ConnectionString);
            var database = client.GetDatabase(mongoDbConfig.Value.DatabaseName);
            _salesCollection = database.GetCollection<Sale>("Sales");
        }

        public async Task<List<Sale>> GetAllAsync() => await _salesCollection.Find(s => true).ToListAsync();

        public async Task<Sale> GetByIdAsync(string id) =>
            await _salesCollection.Find(s => s.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Sale sale) => await _salesCollection.InsertOneAsync(sale);

        public async Task UpdateAsync(string id, Sale sale) =>
            await _salesCollection.ReplaceOneAsync(s => s.Id == id, sale);

        public async Task DeleteAsync(string id) =>
            await _salesCollection.DeleteOneAsync(s => s.Id == id);
    }
}
