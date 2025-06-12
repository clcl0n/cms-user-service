using System.Threading;
using System.Threading.Tasks;
using Cms.UserService.Application.Contracts;

namespace Cms.UserService.Application.Services.Interfaces;

public interface IUserService
{
    Task<UserGetByIdResponse?> GetByIdAsync(
        UserGetByIdRequest request,
        CancellationToken cancellationToken
    );

    Task<UserCreateResponse> CreateAsync(
        UserCreateRequest request,
        CancellationToken cancellationToken
    );

    Task DeleteAsync(UserDeleteRequest request, CancellationToken cancellationToken);
}
