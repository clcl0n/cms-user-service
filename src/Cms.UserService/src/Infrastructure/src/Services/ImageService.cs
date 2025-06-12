using System;
using System.Threading;
using System.Threading.Tasks;
using Cms.Contracts;
using Cms.UserService.Infrastructure.Services.Interfaces;
using Wolverine;

namespace Cms.UserService.Infrastructure.Services;

internal sealed class ImageService(IMessageBus bus) : IImageService
{
    public Task<ImageGetByIdResponse> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return bus.InvokeAsync<ImageGetByIdResponse>(
            new ImageGetByIdRequest(id),
            cancellationToken
        );
    }
}
