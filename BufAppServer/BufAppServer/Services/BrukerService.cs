using BufAppServer.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BufAppServer.Services;

public class BrukerService
{
    private readonly IMongoCollection<Bruker> _brukerCollection;
    public BrukerService(IOptions<AppDatabaseSettings> appDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            appDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            appDatabaseSettings.Value.DatabaseName);

        _brukerCollection = mongoDatabase.GetCollection<Bruker>(
            appDatabaseSettings.Value.BrukerCollectionName);
    }
    
    public async Task<List<Bruker>> GetAsync() =>
        await _brukerCollection.Find(_ => true).ToListAsync();

    public async Task<Bruker?> GetAsync(string id) =>
        await _brukerCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
    
    public async Task<Bruker?> GetAsyncById(string id) =>
        await _brukerCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
    
    public async Task CreateAsync(Bruker newBruker) =>
        await _brukerCollection.InsertOneAsync(newBruker);

    public async Task UpdateAsync(string id, Bruker updatedBruker) =>
        await _brukerCollection.ReplaceOneAsync(x => x.Id == id, updatedBruker);

    public async Task RemoveAsync(string id) =>
        await _brukerCollection.DeleteOneAsync(x => x.Id == id);
}