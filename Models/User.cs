using MongoDB.Bson.Serialization.Attributes;

namespace ShookREST.Models
{
    // Data class of one user.
    [BsonIgnoreExtraElements]
    public class User
    {
        // First name of the user.
        public string FirstName { get; set; }

        // Last name of the user.
        public string LastName { get; set; }

        // Address of the user. Every user has an address.
        public Address Address { get; set; }
    }
}
