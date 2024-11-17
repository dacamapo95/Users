using Users.Application.Core.Abstractions;
using Users.Shared;

namespace Users.API.Features.Countries.Get;

public sealed record GetCountriesQuery : IQuery<MasterEntityResponse<Guid>[]>;