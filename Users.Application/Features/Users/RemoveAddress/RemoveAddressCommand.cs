
using Users.Application.Core.Abstractions;

namespace Users.Application.Features.Users.RemoveAddress;

public record RemoveAddressCommand(
    Guid UserId,
    Guid AddressId) : ICommand;