using System.Collections.Generic;
using System.Threading.Tasks;

using MongoDB.Driver;
using ShookREST.Models;

namespace ShookREST.Util
{
    public class DBUtil
    {
        // Returns a list with all available users that are stored in the
        // MongoDB.
        public async Task<List<User>> ListAllUsers()
        {
            // Create a new client.
            var client = new MongoClient(StaticStrings.DB_CONNECTION_STRING);

            // Get the database shookDatabase.
            var db = client.GetDatabase("shookDatabase");

            // Get the collection Users.
            IMongoCollection<User> SpeCollection = db.GetCollection<User>("Users");

            // Create a list of all documents that are available in the collection
            // Users.
            List<User> documents = await SpeCollection.Find(_ => true).ToListAsync();

            return documents;
        }
    }
}
