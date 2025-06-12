using System;

namespace Cms.UserService.Application.Contracts;

public sealed record UserCreateResponse(Guid Id, Guid ImageId, string FirstName, string LastName);
