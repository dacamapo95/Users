using Users.Application.Core.Abstractions;
using Users.Domain.Errors;
using Users.Domain.Repositories;
using Users.Domain.Result;

namespace Users.Application.Features.Users.Delete;

public class DeleteUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork) : ICommandHandler<DeleteUserCommand>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id, cancellationToken);

        if (user is null)
        {
            return UserErrors.UserNotFound(request.Id);
        }

        _userRepository.Remove(user);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
