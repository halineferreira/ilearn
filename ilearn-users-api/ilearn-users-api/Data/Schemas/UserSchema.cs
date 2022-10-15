using ilearn_users_api.Domain.Entities;
using ilearn_users_api.Domain.ValueObjects;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ilearn_users_api.Data.Schemas
{
    public class UserSchema
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public AddressSchema Address { get; set; }

    }

    public static class UserSchemaExtension
    {
        public static User ConvertToDomain(this UserSchema document)
        {
            var user = new User(document.Id, document.Name, document.Email, document.Phone, document.Password);
            var address = new Address(document.Address.Street, document.Address.Number, document.Address.City, document.Address.State, document.Address.Country, document.Address.ZipCode);
            user.AttributeAddress(address);

            return user;
        }
    }
}
