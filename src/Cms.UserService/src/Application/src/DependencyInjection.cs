using Cms.UserService.Application.Services.Interfaces;
using Cms.UserService.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cms.UserService.Application;

public static class DependencyInjection
{
    public static void AddApplication(
        this IServiceCollection services,
        IHealthChecksBuilder healthChecksBuilder,
        IConfiguration configuration
    )
    {
        services.AddInfrastructure(healthChecksBuilder, configuration);

        services.AddScoped<IUserService, Services.UserService>();
    }
}
