using Users.Application.Core.Abstractions;
using Users.Shared;

namespace Users.Application.Features.Users.GetById;

public sealed record GetUserByIdQuery(Guid Id) : IQuery<UserDetailResponse>;