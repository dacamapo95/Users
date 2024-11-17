using Users.Domain.Entities;

namespace Users.Domain.Repositories;

public interface ICountryRepository
{
    Task<List<Country>> GetCountriesAsync(CancellationToken cancellationToken = default);
}