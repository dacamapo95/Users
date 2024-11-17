using Mapster;
using Users.Application.Core.Abstractions;
using Users.Domain.Repositories;
using Users.Domain.Result;
using Users.Shared;

namespace Users.Application.Features.Users.Get;
internal class GetUsersQueryHandler(IUserRepository userRepository) : IQueryHandler<GetUsersQuery, UserResponse[]>
{
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<Result<UserResponse[]>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAsync(cancellationToken);
        return users.Adapt<UserResponse[]>();
    }
}
