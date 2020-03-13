using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using ShookModel.Models;
using ShookREST.Util.MongoDB;

namespace ShookREST.Util
{
    public class UserRepositoryImpl : IUserRepository
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
            var user = _database.GetCollection<User>("users").Find(query).ToListAsync();

            return user.Result.FirstOrDefault();
        }

        public User GetByUsernameAndPassword(string username, string password)
        {
            var queryUsername = Builders<User>.Filter.Eq(e => e.UserData.UserName, username);
            var queryPassword = Builders<User>.Filter.Eq(e => e.UserData.Password, password);
            var combinedFilters = Builders<User>.Filter.And(queryUsername, queryPassword);
            // TODO: Password hashing algorithm to find the password in the database.
            var user = _database.GetCollection<User>("users").Find(combinedFilters).ToListAsync();

            return user.Result.FirstOrDefault();
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
