using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ShookREST.Models
{
    public class User
    {
        public ObjectId Id { get; set; }

        [BsonElement("FirstName")]
        public string FirstName { get; set; }

        [BsonElement("LastName")]
        public string LastName { get; set; }

        [BsonElement("Address")]
        public Address Address { get; set; }
    }
}
