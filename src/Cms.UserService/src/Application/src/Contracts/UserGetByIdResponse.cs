using System;

namespace Cms.UserService.Application.Contracts;

public sealed record UserGetByIdResponse(
    Guid Id,
    string FirstName,
    string LastName,
    UserGetByIdResponseImage Image
);
