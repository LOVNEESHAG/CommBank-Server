using MongoDB.Driver;
using CommBank.Models;

namespace CommBank.Services;

public class MongoDbService
{
    private readonly IMongoDatabase _database;

    public MongoDbService(IConfiguration config)
    {
        var connectionString = config["MongoDbSettings:ConnectionString"];
        var databaseName = config["MongoDbSettings:DatabaseName"];

        var client = new MongoClient(connectionString);
        _database = client.GetDatabase(databaseName);
    }

    // 👉 Get Goals Collection
    public IMongoCollection<Goal> GoalsCollection =>
        _database.GetCollection<Goal>("Goals");
}