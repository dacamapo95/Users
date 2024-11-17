using Users.Application.Core.Abstractions;

namespace Users.Application.Features.Users.AddAddress;

public record AddAddressCommand(
     Guid UserId,
     string Street,
     Guid CityId,
     string? ZipCode
    ) : ICommand;