using ilearn_ui.domain.Dtos.Response;
using ilearn_ui.services.Extensions;
using ilearn_ui.services.Translators;

namespace ilearn_ui.services
{
    public interface IUserService
    {
        Task<UsersResponseDto> SearchUsersAsync();
    }
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<UsersResponseDto> SearchUsersAsync()
        {

            HttpClient client = new HttpClient();
            var response = await client.GetAsync("https://localhost:7299/user/all");
            var responseBody = await response.Content.ReadAsStringAsync();

            var userResponseDto = DtoExtensions.Deserialize<UsersResponse>(responseBody);

            //if (jsonObject != null)
            //    return jsonObject;
            //else
            //    return UsersResponseDto { new UserDto() };

            //var userResponseDto = DtoExtensions.Deserialize<UsersResponse>(responseBody);

            return UserTranslator.UsersResponseToDto(userResponseDto); ;

        }
    }
}