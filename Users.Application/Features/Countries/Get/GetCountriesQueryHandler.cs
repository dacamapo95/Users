using Mapster;
using Users.Application.Core.Abstractions;
using Users.Domain.Entities;
using Users.Domain.Errors;
using Users.Domain.Repositories;
using Users.Domain.Result;
using Users.Shared;

namespace Users.API.Features.Countries.Get;

public sealed class GetCountriesQueryHandler(ICountryRepository countryRepository) : IQueryHandler<GetCountriesQuery, MasterEntityResponse<Guid>[]>
{
    private readonly ICountryRepository _countryRepository = countryRepository;

    public async Task<Result<MasterEntityResponse<Guid>[]>> Handle(GetCountriesQuery request, CancellationToken cancellationToken)
    {
        var countries = await _countryRepository.GetCountriesAsync(cancellationToken);

        if (countries.Count == 0)
            return SharedErrors.MasterEntityNotFound(nameof(Country));

        return countries.Adapt<MasterEntityResponse<Guid>[]>();
    }
}