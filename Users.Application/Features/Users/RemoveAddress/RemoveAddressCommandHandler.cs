using Users.Application.Core.Abstractions;
using Users.Domain.Errors;
using Users.Domain.Repositories;
using Users.Domain.Result;

namespace Users.Application.Features.Users.RemoveAddress;

public sealed class RemoveAddressCommandHandler(
    IUnitOfWork unitOfWork, 
    IUserRepository userRepository) : ICommandHandler<RemoveAddressCommand>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<Result> Handle(RemoveAddressCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserWithAddresses(request.UserId, cancellationToken);

        if (user is null)
        {
            return UserErrors.UserNotFound(request.UserId);
        }

        var address = user.Addresses.FirstOrDefault(a => a.Id == request.AddressId);

        if (address is null)
        {
            return UserErrors.AddressNotFound(request.AddressId);
        }

        user.Addresses.Remove(address);
        _userRepository.Update(user);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
