using Users.Application.Core.Abstractions;
using Users.Shared;

namespace Users.Application.Features.Users.Get;
public record  GetUsersQuery : IQuery<UserResponse[]>;