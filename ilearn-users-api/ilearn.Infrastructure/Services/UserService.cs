using ilearn.Data;
using ilearn.Domain.Models;
using ilearn.Domain.Responses;

namespace ilearn.Infrastructure.Services
{
    public interface IUserService
    {
        Task<UsersResponse> SearchAsync();
        Task<UsersResponse> SearchAsync(UsersRequest searchUsersQuery, Pagination pagination, CancellationToken cancellationToken = default);


    }

    public class UserInterface : IUserService
    {
        public async Task<UsersResponse> SearchAsync()
        {
                ValidateAssetsSearchRequest(searchAssetsQuery);
                return await _assetSearchUseCase.SearchAsync(searchAssetsQuery, pagination ?? new Pagination(), cancellationToken);
        }
    }
}
