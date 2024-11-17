using Users.Application.Core.Abstractions;

namespace Users.Application.Features.Users.Delete;

public record DeleteUserCommand(Guid Id) : ICommand;
