using Users.Application.Core.Abstractions;
using Users.Shared;

namespace Users.API.Features.Countries.GetCitiesByCountry;

public sealed record GetCitiesByCountryQuery(Guid CountryId) : IQuery<MasterEntityResponse<Guid>[]>;