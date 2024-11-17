
using Users.Domain.Result;

namespace Users.Domain.Errors;

public static class SharedErrors
{
    public static Error MasterEntityNotFound(string entityName) =>
        Error.NotFound($"Master {entityName} not found.");
}
