using ilearn_ui.domain.Dtos;
using ilearn_ui.domain.Dtos.Response;
using ilearn_ui.services.Extensions;
using ilearn_ui.services.Translators;
using Newtonsoft.Json;

namespace ilearn_ui.services
{
    public interface IUserService
    {
        Task<List<UserDto>> SearchBySubjectAsync(string subject);
        Task<List<UserDto>> SearchBySubjectAndLocationAsync(string subject, string location);
    }
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<UserDto>> SearchBySubjectAsync(string subject)
        {

            HttpClient client = new HttpClient();
            var response = await client.GetAsync($"https://localhost:7299/api/user/{subject}");
            var responseBody = await response.Content.ReadAsStringAsync();

            var users = JsonConvert.DeserializeObject<List<UserDto>>(responseBody);

            //var userResponseDto = DtoExtensions.Deserialize<IEnumerable<UserDto>>(responseBody);

            //if (jsonObject != null)
            //    return jsonObject;
            //else
            //    return UsersResponseDto { new UserDto() };

            //var userResponseDto = DtoExtensions.Deserialize<UsersResponse>(responseBody);

            return users;

            //return new UsersResponseDto();

        }

        public async Task<List<UserDto>> SearchBySubjectAndLocationAsync(string subject, string location)
        {

            HttpClient client = new HttpClient();
            var response = await client.GetAsync($"https://localhost:7299/api/user/{subject}/{location}");
            var responseBody = await response.Content.ReadAsStringAsync();

            var users = JsonConvert.DeserializeObject<List<UserDto>>(responseBody);

            return users;
        }
    }
}