using System;
using Cms.UserService.Infrastructure.Persistence;
using Cms.UserService.Infrastructure.Persistence.UnitOfWork;
using Cms.UserService.Infrastructure.Persistence.UnitOfWork.Interfaces;
using Cms.UserService.Infrastructure.Services;
using Cms.UserService.Infrastructure.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cms.UserService.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(
        this IServiceCollection services,
        IHealthChecksBuilder healthChecksBuilder,
        IConfiguration configuration
    )
    {
        healthChecksBuilder.AddInfrastructureHealthChecks(configuration);

        services.AddDbContext(configuration);
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IImageService, ImageService>();
    }

    public static void AddCliInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddDbContext(configuration);

        services.AddScoped<IPersistenceService, PersistenceService>();
    }

    public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DbContext, UserDbContext>(
            (provider, opts) =>
            {
                opts.UseNpgsql(
                        configuration.GetConnectionString("Postgres"),
                        x => x.MigrationsHistoryTable("__EFMigrationsHistory", "cms-user-service")
                    )
                    .UseSnakeCaseNamingConvention()
                    .ConfigureWarnings(x =>
                    {
                        x.Ignore(
                            CoreEventId.PossibleIncorrectRequiredNavigationWithQueryFilterInteractionWarning
                        );
                    });
            }
        );
    }

    private static IHealthChecksBuilder AddInfrastructureHealthChecks(
        this IHealthChecksBuilder builder,
        IConfiguration configuration
    )
    {
        builder.AddNpgSql(
            configuration.GetConnectionString("Postgres")
                ?? throw new NullReferenceException("Postgres connection string was not found.")
        );

        return builder;
    }
}
