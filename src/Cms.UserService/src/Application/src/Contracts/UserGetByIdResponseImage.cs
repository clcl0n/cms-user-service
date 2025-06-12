using System;

namespace Cms.UserService.Application.Contracts;

public sealed record UserGetByIdResponseImage(Guid Id, string FileName);
