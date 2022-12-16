using MongoDB.Bson.Serialization.Attributes;
namespace ilearn_users_api.Data.Schemas
{
    public class AddressSchema
    {
        public AddressSchema() { }

        public AddressSchema(string street, string number, string city, string state, string country, string zipCode)
        {
            Street = street;
            Number = number;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;
        }
        [BsonElement("Street")]
        public string Street { get; set; }
        [BsonElement("Number")]
        public string Number { get; set; }
        [BsonElement("City")]
        public string City { get; set; }
        [BsonElement("State")]
        public string State { get; set; }
        [BsonElement("Country")]
        public string Country { get; set; }
        [BsonElement("ZipCode")]
        public string ZipCode { get; set; }
    }
}
