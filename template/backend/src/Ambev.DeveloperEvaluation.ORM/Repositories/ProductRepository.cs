using Ambev.DeveloperEvaluation.Domain.Models;
using MongoDB.Driver;

public class ProductRepository
{
    private readonly IMongoCollection<Product> _products;

    public ProductRepository(MongoDbService mongoDbService)
    {
        _products = mongoDbService.GetCollection<Product>("Products");
    }

    public async Task<List<Product>> GetAllAsync() => await _products.Find(_ => true).ToListAsync();

    public async Task<Product> GetByIdAsync(string id) => await _products.Find(p => p.Id == id).FirstOrDefaultAsync();

    public async Task AddAsync(Product product) => await _products.InsertOneAsync(product);

    public async Task UpdateAsync(Product product) => await _products.ReplaceOneAsync(p => p.Id == product.Id, product);

    public async Task DeleteAsync(string id) => await _products.DeleteOneAsync(p => p.Id == id);
}
