using Mapster;
using Users.Application.Core.Abstractions;
using Users.Domain.Entities;
using Users.Domain.Errors;
using Users.Domain.Repositories;
using Users.Domain.Result;
using Users.Shared;

namespace Users.API.Features.Countries.GetCitiesByCountry;

public sealed class GetCitiesByCountryQueryHandler(ICityRepository cityRepository)
    : IQueryHandler<GetCitiesByCountryQuery, MasterEntityResponse<Guid>[]>
{
    private readonly ICityRepository _cityRepository = cityRepository;

    public async Task<Result<MasterEntityResponse<Guid>[]>> Handle(GetCitiesByCountryQuery request, CancellationToken cancellationToken)
    {
        var cities = await _cityRepository.GetCitiesAsync(request.CountryId, cancellationToken);

        if (cities.Count == 0) return SharedErrors.MasterEntityNotFound(nameof(City));

        return cities.Adapt<MasterEntityResponse<Guid>[]>();
    }
}
