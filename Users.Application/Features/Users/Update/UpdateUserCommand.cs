using Users.Application.Core.Abstractions;
using Users.Application.Features.Users.Create;

namespace Users.Application.Features.Users.Update;

public sealed record UpdateUserCommand(
    Guid Id,
    string UserName,
    string Email,
    string Password,
    string FirstName,
    string? SecondName,
    string LastName,
    string? SecondLastName) : BaseUserCommand(
        UserName,
        Email,
        Password,
        FirstName,
        SecondName,
        LastName,
        SecondLastName), ICommand;