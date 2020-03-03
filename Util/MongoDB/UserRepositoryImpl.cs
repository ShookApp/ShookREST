using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using ShookModel.Models;
using ShookREST.Util.MongoDB;

namespace ShookREST.Util
{
    public class UserRepositoryImpl : IMongoRepository
    {
        private readonly IMongoDatabase _database;

        public UserRepositoryImpl()
        {
            _database = Connect();
        }

        private IMongoDatabase Connect()
        {
            var client = new MongoClient(StaticStrings.DB_CONNECTION_STRING);
            var database = client.GetDatabase("shookDatabase");

            return database;
        }

        public void Add(User user)
        {
            _database.GetCollection<User>("users").InsertOneAsync(user);
        }

        public IEnumerable<User> AllUsers()
        {
            var users = _database.GetCollection<User>("users").Find(new BsonDocument()).ToListAsync();

            return users.Result;
        }

        public User GetById(ObjectId id)
        {
            var query = Builders<User>.Filter.Eq(e => e.Id, id);
            var speaker = _database.GetCollection<User>("users").Find(query).ToListAsync();

            return speaker.Result.FirstOrDefault();
        }

        public Boolean Remove(ObjectId id)
        {
            var query = Builders<User>.Filter.Eq(e => e.Id, id);
            var result = _database.GetCollection<User>("users").DeleteOneAsync(query);

            return GetById(id) == null;
        }

        public void Update(User user)
        {
            var query = Builders<User>.Filter.Eq(e => e.Id, user.Id);
            var update = _database.GetCollection<User>("users").ReplaceOneAsync(query, user);
        }
    }
}
