using ilearn_users_api.Controllers.Responses;
using ilearn_users_api.Data.Schemas;
using ilearn_users_api.Domain.Entities;
using ilearn_users_api.Domain.ValueObjects;
using Microsoft.Extensions.Hosting;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using static MongoDB.Driver.WriteConcern;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using AutoMapper;

namespace ilearn_users_api.Data.Repositories
{
    public class UserRepository
    {
        IMongoCollection<UserSchema> _users;
        private readonly IMapper _mapper;

        public UserRepository(MongoDB mongoDB, IMapper mapper)
        {
            _users = mongoDB.DB.GetCollection<UserSchema>("users");
            _mapper = mapper;
        }

        public void Insert(User user)
        {
            
            //var document = new UserSchema
            //{
            //    Name = user.Name,
            //    Email = user.Email,
            //    Password = user.Password,
            //    Phone = user.Phone,
            //    Address = new AddressSchema
            //    {
            //        Street = user.Address.Street,
            //        Number = user.Address.Number,
            //        City = user.Address.City,
            //        State = user.Address.State,
            //        Country = user.Address.Country,
            //        ZipCode = user.Address.ZipCode

            //    }
            //};

            _users.InsertOne(_mapper.Map<UserSchema>(user));
        }

        public async Task<List<User>> SearchBySubjectAsync(string subject)
        {
            Expression<Func<UserSchema, bool>> filter = u => u.Subjects.Any(s => s.Name.Contains(subject));
            var users = _users.Find(filter).ToList();

            return _mapper.Map<List<User>>(users);
        }

        public async Task<List<User>> SearchBySubjectAndLocationAsync(string subject, string location)
        {
            Expression<Func<UserSchema, bool>> filter = u => u.Subjects.Any(s => s.Name.Contains(subject)) && u.Address.City.Contains(location);
            var users = _users.Find(filter).ToList();

            return _mapper.Map<List<User>>(users);
        }

        public async Task<User> SearchByIdAsync(ObjectId id)
        {
            Expression<Func<UserSchema, bool>> filter = x => x.Id.Equals(id);
            UserSchema user = _users.Find(filter).FirstOrDefault();

            return _mapper.Map<User>(user);
        }

       


    }
}
