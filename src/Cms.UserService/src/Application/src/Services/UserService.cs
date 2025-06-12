using System.Threading;
using System.Threading.Tasks;
using Cms.UserService.Application.Contracts;
using Cms.UserService.Application.Services.Interfaces;
using Cms.UserService.Domain.Entities;
using Cms.UserService.Infrastructure.Persistence.UnitOfWork.Interfaces;
using Cms.UserService.Infrastructure.Services.Interfaces;

namespace Cms.UserService.Application.Services;

internal sealed class UserService(IUnitOfWork unitOfWork, IImageService imageService) : IUserService
{
    public async Task<UserGetByIdResponse?> GetByIdAsync(
        UserGetByIdRequest request,
        CancellationToken cancellationToken
    )
    {
        var user = await unitOfWork.UserRepository.GetByIdAsync(request.Id, cancellationToken);

        if (user is null)
        {
            return null;
        }

        var image = await imageService.GetByIdAsync(user.ImageId, cancellationToken);

        return new UserGetByIdResponse(
            user.Id,
            user.FirstName,
            user.LastName,
            new UserGetByIdResponseImage(image.Id, image.FileName)
        );
    }

    public async Task<UserCreateResponse> CreateAsync(
        UserCreateRequest request,
        CancellationToken cancellationToken
    )
    {
        var userToCreate = new User(default, request.ImageId, request.FirstName, request.LastName);

        var createdUser = await unitOfWork.UserRepository.InsertAsync(
            userToCreate,
            cancellationToken
        );

        return new UserCreateResponse(
            createdUser.Id,
            createdUser.ImageId,
            createdUser.FirstName,
            createdUser.LastName
        );
    }

    public async Task DeleteAsync(UserDeleteRequest request, CancellationToken cancellationToken)
    {
        await unitOfWork.UserRepository.DeleteAsync(request.Id, cancellationToken);
    }
}
