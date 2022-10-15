using ilearn_users_api.Data.Schemas;
using ilearn_users_api.Domain.Entities;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace ilearn_users_api.Data
{
    public class MongoDB
    {
        public IMongoDatabase DB { get; }
        public MongoDB(IConfiguration configuration)
        {
            try
            {
                var client = new MongoClient(configuration["ConnectionString"]);
                DB = client.GetDatabase(configuration["DataBaseName"]);
                MapClasses();
            }
            catch (Exception ex)
            {
                throw new MongoException("Não foi possível conectar ao banco de dados", ex);
            }
        }

        private void MapClasses()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(UserSchema)))
            {
                BsonClassMap.RegisterClassMap<UserSchema>(i =>
                {
                    i.AutoMap();
                    i.MapIdMember(c => c.Id);
                    i.SetIgnoreExtraElements(true);
                });
            }
        }
    }
}
