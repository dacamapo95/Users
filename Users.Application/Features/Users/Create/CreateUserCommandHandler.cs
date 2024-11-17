using Users.Application.Core.Abstractions;
using Users.Domain.Entities;
using Users.Domain.Errors;
using Users.Domain.Repositories;
using Users.Domain.Result;

namespace Users.Application.Features.Users.Create;

public class CreateUserCommandHandler(
    IUserRepository userRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<CreateUserCommand, Guid>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result<Guid>> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        if (await _userRepository.ExistsByEmailAsync(command.Email, cancellationToken))
        {
            return UserErrors.UserEmailExists(command.Email);
        }

        if (await _userRepository.ExistsByUserNameAsync(command.UserName, cancellationToken))
        {
            return UserErrors.UserNameExists(command.UserName);
        }

        var user = User.Create(
            command.UserName,
            command.Email,
            command.Password, 
            command.FirstName, 
            command.SecondName, 
            command.LastName,
            command.SecondLastName);

        _userRepository.Add(user);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return user.Id;
    }
}
