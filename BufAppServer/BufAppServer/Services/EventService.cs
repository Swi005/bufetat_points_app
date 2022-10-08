using BufAppServer.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BufAppServer.Services;

public class EventService
{
    private readonly IMongoCollection<Event> _eventCollection;
    public EventService(IOptions<AppDatabaseSettings> appDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            appDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            appDatabaseSettings.Value.DatabaseName);

        _eventCollection = mongoDatabase.GetCollection<Event>(
            appDatabaseSettings.Value.EventCollectionName);
    }
    
    public async Task<List<Event>> GetAsync() =>
        await _eventCollection.Find(_ => true).ToListAsync();

    public async Task<Event?> GetAsyncBySubject(string subjectId) =>
        await _eventCollection.Find(x => x.Subject == subjectId).FirstOrDefaultAsync();
    
    public async Task<Event?> GetAsyncByActor(string actorId) =>
        await _eventCollection.Find(x => x.Actor == actorId).FirstOrDefaultAsync();

    public async Task CreateAsync(Event newEvent) =>
        await _eventCollection.InsertOneAsync(newEvent);

    public async Task UpdateAsync(string id, Event updatedEvent) =>
        await _eventCollection.ReplaceOneAsync(x => x.Id == id, updatedEvent);

    public async Task RemoveAsync(string id) =>
        await _eventCollection.DeleteOneAsync(x => x.Id == id);
}