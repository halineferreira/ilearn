using ilearn_users_api.Controllers.Responses;
using ilearn_users_api.Data.Schemas;
using ilearn_users_api.Domain.Entities;
using ilearn_users_api.Domain.ValueObjects;
using MongoDB.Driver;

namespace ilearn_users_api.Data.Repositories
{
    public class UserRepository
    {
        IMongoCollection<UserSchema> _users;

        public UserRepository(MongoDB mongoDB)
        {
            _users = mongoDB.DB.GetCollection<UserSchema>("users");
        }

        public void Insert(User user)
        {
            var document = new UserSchema
            {
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                Phone = user.Phone,
                Address = new AddressSchema
                {
                    Street = user.Address.Street,
                    Number = user.Address.Number,
                    City = user.Address.City,
                    State = user.Address.State,
                    Country = user.Address.Country,
                    ZipCode = user.Address.ZipCode

                }
            };

            _users.InsertOne(document);
        }

        public async Task<List<User>> SearchAsync()
        {
            //var users = new UserList();
            var response = new List<User>();

            await _users.AsQueryable().ForEachAsync(d =>
            {
                var u = new User(d.Id.ToString(), d.Name, d.Email, d.Phone, d.Password);
                var a = new Address(d.Address.Street, d.Address.Number, d.Address.City, d.Address.State, d.Address.Country, d.Address.ZipCode);

                u.AttributeAddress(a);
                response.Add(u);
            });

            //users.Values = response;
            return response;
        }

        //public async Task<IEnumerable<User>> SearchAsync()
        //{
        //    var users = new List<User>();

        //    await _users.AsQueryable().ForEachAsync(d =>
        //    {
        //        var u = new User(d.Id.ToString(), d.Name, d.Email, d.Phone, d.Password);
        //        var a = new Address(d.Address.Street, d.Address.Number, d.Address.City, d.Address.State, d.Address.Country, d.Address.ZipCode);

        //        u.AttributeAddress(a);
        //        users.Add(u);
        //    });
        //    return users;
        //}

        public User GetById(string id)
        {
            var document = _users.AsQueryable().FirstOrDefault(_ => _.Id == id);

            if (document == null)
                return null;

            return document.ConvertToDomain();
        }

        public bool FullUpdate(User user)
        {
            var document = new UserSchema
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                Phone = user.Phone,
                Address = new AddressSchema
                {
                    Street = user.Address.Street,
                    Number = user.Address.Number,
                    City = user.Address.City,
                    State = user.Address.State,
                    Country = user.Address.Country,
                    ZipCode = user.Address.ZipCode
                }
            };

            var result = _users.ReplaceOne(_ => _.Id == document.Id, document);

            return result.ModifiedCount > 0;
        }

        public bool PartialUpdate(string id, Address address)
        {
            var newAddress = new AddressSchema
            {
                Street = address.Street,
                Number = address.Number,
                City = address.City,
                State = address.State,
                Country = address.Country,
                ZipCode = address.ZipCode
            };

            var update = Builders<UserSchema>.Update.Set(_ => _.Address, newAddress);

            var result = _users.UpdateOne(_ => _.Id == id, update);

            return result.ModifiedCount > 0;
        }

        public IEnumerable<User> SearchTeacherByCourseName(string name)//por enquanto vai ser nome da rua
        {
            var availableTeachers = new List<User>();

            _users.AsQueryable()
                .Where(_ => _.Address.Street.ToLower().Contains(name.ToLower()))
                .ToList()
                .ForEach(d => availableTeachers.Add(d.ConvertToDomain()));

            return availableTeachers;
        }
    }
}
