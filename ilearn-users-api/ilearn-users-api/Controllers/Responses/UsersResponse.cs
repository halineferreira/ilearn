using ilearn_users_api.Domain.Entities;

namespace ilearn_users_api.Controllers.Responses
{
    public class UsersResponse
    {
        public int TotalActiveCount { get; set; }
        public ICollection<User> Values { get; set; }
    }
}
