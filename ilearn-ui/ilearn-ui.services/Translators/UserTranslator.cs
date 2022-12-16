using ilearn_ui.domain.Dtos;
using ilearn_ui.domain.Dtos.Response;
using ilearn_ui.domain.Models;

namespace ilearn_ui.services.Translators
{
    public static class UserTranslator
    {
        public static UsersResponseDto UsersResponseToDto(UsersResponse users)
        {
            return new UsersResponseDto
            {
                //TotalCount = usersResponse.TotalCount,
                //TotalActiveCount = usersResponse.TotalActiveCount,
                //Values = usersResponse.Values.Select(ModelToDto).ToList()
                Values = users.users,
            };
        }
        public static UserDto ModelToDto(User model)
        {
            return new UserDto
            {
                Id = model.Id,
                Name = model.Name,
                Email = model.Email,
                //Street = model.Address.Street,
                //Number = model.Address.Number,
                //City = model.Address.City,
                //State = model.Address.State,
                //Country = model.Address.Country,
                //ZipCode = model.Address.ZipCode,
                //Address = model.Address ?,
                Phone = model.Phone,
                //Password = model.Password
            };
        }
    }
}
