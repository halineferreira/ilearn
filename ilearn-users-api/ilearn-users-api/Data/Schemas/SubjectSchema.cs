using MongoDB.Bson.Serialization.Attributes;

namespace ilearn_users_api.Data.Schemas
{
    public class SubjectSchema
    {
        public SubjectSchema() { }

        public SubjectSchema(string name, string description)
        {
            Name = name;
            Description = description;
        }
        [BsonElement("Name")]
        public string Name { get; set; }
        [BsonElement("Description")]
        public string Description { get; set; }

    }
}
