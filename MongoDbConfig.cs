public class MongoDbConfig
{
    public string ConnectionString { get; set; } = string.Empty;
    public string DatabaseName { get; set; } = string.Empty;
}
public interface IMongoDbContext
{
    IMongoCollection<Sale> Sales { get; }
    IMongoCollection<Product> Products { get; }
}
public class MongoDbService : IMongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbService(IMongoClient client)
    {
        _database = client.GetDatabase("DevStoreABI");
    }

    public IMongoCollection<Sale> Sales => _database.GetCollection<Sale>("Sales");
    public IMongoCollection<Product> Products => _database.GetCollection<Product>("Products");
}
