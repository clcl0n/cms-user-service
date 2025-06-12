using System;

namespace Cms.UserService.Domain.Entities;

public record User(Guid Id, Guid ImageId, string FirstName, string LastName) : BaseEntity(Id);
