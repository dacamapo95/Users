using Users.Domain.Entities;

namespace Users.Domain.Repositories;

public interface ICityRepository
{
    Task<List<City>> GetCitiesAsync(Guid countryId, CancellationToken cancellation = default);
}