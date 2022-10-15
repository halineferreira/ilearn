using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ilearn.Domain.Models
{
    public class UsersRequest
    {
        //public List<IdentifierFilter>? Identifiers { get; set; }
        public UsersFilter? Filters { get; set; }
    }
}
