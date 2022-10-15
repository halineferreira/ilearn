using ilearn_users_api.Domain.Entities;

namespace ilearn_users_api.Controllers.Responses
{
    public class UserList
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public AddressDto Address { get; set; }

        //new
        //public IEnumerable<UserDto> Values { get; set; }
    }
}
