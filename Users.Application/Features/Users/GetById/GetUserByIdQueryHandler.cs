using Mapster;
using Users.Application.Core.Abstractions;
using Users.Domain.Errors;
using Users.Domain.Repositories;
using Users.Domain.Result;
using Users.Shared;

namespace Users.Application.Features.Users.GetById;

public class GetUserByIdQueryHandler(
    IUserRepository userRepository) : IQueryHandler<GetUserByIdQuery, UserDetailResponse>
{
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<Result<UserDetailResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id, cancellationToken);
    
        if (user is null)
        {
            return UserErrors.UserNotFound(request.Id);
        }

        return user.Adapt<UserDetailResponse>();
    }
}