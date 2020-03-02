using MongoDB.Bson.Serialization.Attributes;

namespace ShookREST.Models
{
    public class Address
    {
        [BsonElement("Street")]
        public string Street { get; set; }

        [BsonElement("HouseNumber")]
        public string HouseNumber { get; set; }

        [BsonElement("City")]
        public string City { get; set; }

        [BsonElement("ZipCode")]
        public string ZipCode { get; set; }
    }
}
