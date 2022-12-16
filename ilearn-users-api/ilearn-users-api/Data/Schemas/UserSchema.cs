using ilearn_users_api.Domain.Entities;
using ilearn_users_api.Domain.ValueObjects;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ilearn_users_api.Data.Schemas
{
    [BsonIgnoreExtraElements]
    public class UserSchema
    {
        [BsonId()]
        public ObjectId Id { get; set; }
        [BsonElement("Name")]
        public string Name { get; set; }
        [BsonElement("Email")]
        public string Email { get; set; }
        [BsonElement("Phone")]
        public string Phone { get; set; }
        [BsonElement("Password")]
        public string Password { get; set; }
        [BsonElement("Address")]
        public AddressSchema Address { get; set; }
        [BsonElement("Subjects")]
        public List<SubjectSchema> Subjects { get; set; } = new List<SubjectSchema>();

    }

    public static class UserSchemaExtension
    {
        public static User ConvertToDomain(this UserSchema document)
        {
            //var subjects = document.Subjects;
            var address = new Address(document.Address.Street, document.Address.Number, document.Address.City, document.Address.State, document.Address.Country, document.Address.ZipCode);
            var user = new User(document.Id, document.Name, document.Email, document.Phone, document.Password);
            user.AttributeAddress(address);

            return user;
        }
    }
}
