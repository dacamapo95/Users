using Mapster;
using Users.Application.Core.Abstractions;
using Users.Domain.Errors;
using Users.Domain.Repositories;
using Users.Domain.Result;

namespace Users.Application.Features.Users.Update;

public class UpdateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork) : ICommandHandler<UpdateUserCommand>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;   

    public async Task<Result> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id, cancellationToken);

        if (user is null)
        {
            return UserErrors.UserNotFound(request.Id);
        }

        request.Adapt(user);
        _userRepository.Update(user);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
