using System.Threading.Tasks;
using Cms.Cli;
using Cms.Cli.Extensions;
using Cms.UserService.Cli.Commands;
using Cms.UserService.Infrastructure;

namespace Cms.UserService.Cli;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var builder = CliBuilder.CreateCliBuilder(args);

        builder.Services.AddCliInfrastructure(builder.Configuration);

        builder.Services.AddCommand<ApplyMigrationsCommand>("apply-migrations");

        await CliBuilder.RunCliAsync(builder);
    }
}
