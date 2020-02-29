namespace ShookREST.Models
{
    // Address class. Every user has one address.
    public class Address
    {
        // Street name of the address.
        public string Street { get; set; }

        // House number of the address.
        public string HouseNumber { get; set; }

        // City of the address
        public string City { get; set; }

        // Zip code of the address.
        public string ZipCode { get; set; }
    }
}
