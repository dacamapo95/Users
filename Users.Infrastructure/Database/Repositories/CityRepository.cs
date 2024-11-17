using Microsoft.EntityFrameworkCore;
using Users.Domain.Entities;
using Users.Domain.Repositories;

namespace Users.Infrastructure.Database.Repositories;

internal sealed class CityRepository(ApplicationDbContext context) : ICityRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<List<City>> GetCitiesAsync(Guid countryId, CancellationToken cancellationToken) =>
        await _context.Cities.Where(city => city.CountryId == countryId)
        .AsNoTracking()
        .ToListAsync(cancellationToken);
}
