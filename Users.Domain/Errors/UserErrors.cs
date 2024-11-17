using Users.Domain.Result;

namespace Users.Domain.Errors;
public static class UserErrors
{
    public static Error UserNotFound(Guid id) =>
        Error.NotFound($"User with id {id} not found.");

    public static Error AddressNotFound(Guid addressId) =>
        Error.NotFound($"Address with id {addressId} not found.");

    public static Error UserNameExists(string userName) =>
        Error.Conflict($"User with user name {userName} already exists.");

    public static Error UserEmailExists(string email) =>
        Error.Conflict($"User with email {email} already exists.");

}
