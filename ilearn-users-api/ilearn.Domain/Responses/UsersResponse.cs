using ilearn.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ilearn.Domain.Responses
{
    public class UsersResponse
    {
        public int TotalCount { get; set; }
        public ICollection<User> Values { get; set; }
    }
}
