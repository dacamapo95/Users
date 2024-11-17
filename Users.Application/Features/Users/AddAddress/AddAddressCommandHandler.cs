using Users.Application.Core.Abstractions;
using Users.Domain.Entities;
using Users.Domain.Errors;
using Users.Domain.Repositories;
using Users.Domain.Result;

namespace Users.Application.Features.Users.AddAddress;

public class AddAddressCommandHandler(IUnitOfWork unitOfWork, IUserRepository userRepository) : ICommandHandler<AddAddressCommand>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<Result> Handle(AddAddressCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId, cancellationToken);

        if (user is null)
        {
            return UserErrors.UserNotFound(request.UserId);
        }

        var address = Address.Create(request.Street, request.CityId, request.ZipCode);
        user.Addresses.Add(address);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }

}
