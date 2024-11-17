using Users.Application.Core.Abstractions;

namespace Users.Application.Features.Users.Create;

public sealed record CreateUserCommand(
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
        SecondLastName), ICommand<Guid>;

public abstract record BaseUserCommand(
    string UserName,
    string Email,
    string Password,
    string FirstName,
    string? SecondName,
    string LastName,
    string? SecondLastName);