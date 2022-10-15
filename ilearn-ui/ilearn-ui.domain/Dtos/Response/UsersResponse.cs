namespace ilearn_ui.domain.Dtos.Response
{
    public class UsersResponse
    {
        //public int PageNumber { get; set; }
        //public int PageSize { get; set; }
        //public int TotalCount { get; set; }
        //public int TotalActiveCount { get; set; }
        //public ICollection<User> Values { get; set; }

        public IEnumerable<UserDto> users { get; set; }
    }

    //public class Data
    //{
    //    public IEnumerable<UserDto> users {get; set;}
    //}
}
