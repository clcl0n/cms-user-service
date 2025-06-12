using System;

namespace Cms.UserService.Application.Contracts;

public sealed record UserCreateRequest(Guid ImageId, string FirstName, string LastName);
