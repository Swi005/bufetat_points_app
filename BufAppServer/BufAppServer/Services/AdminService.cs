﻿using BufAppServer.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BufAppServer.Services;

public class AdminService
{
    private readonly IMongoCollection<Admin> _adminCollection;
    public AdminService(IOptions<AppDatabaseSettings> appDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            appDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            appDatabaseSettings.Value.DatabaseName);

        _adminCollection = mongoDatabase.GetCollection<Admin>(
            appDatabaseSettings.Value.AdminCollectionName);
    }
    
    public async Task<List<Admin>> GetAsync() =>
        await _adminCollection.Find(_ => true).ToListAsync();

    public async Task<Admin?> GetAsyncByUser(string userId) =>
        await _adminCollection.Find(x => x.User == userId).FirstOrDefaultAsync();
    public async Task<Admin?> GetAsync(string id) =>
        await _adminCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Admin newAdmin) =>
        await _adminCollection.InsertOneAsync(newAdmin);

    public async Task UpdateAsync(string id, Admin updatedAdmin) =>
        await _adminCollection.ReplaceOneAsync(x => x.Id == id, updatedAdmin);

    public async Task RemoveAsync(string id) =>
        await _adminCollection.DeleteOneAsync(x => x.Id == id);
}