using Microsoft.EntityFrameworkCore;
using Users.Domain.Entities;
using Users.Domain.Repositories;

namespace Users.Infrastructure.Database.Repositories;

internal sealed class CountryRepository(ApplicationDbContext context) : ICountryRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<List<Country>> GetCountriesAsync(CancellationToken cancellationToken = default) =>
        await _context.Countries.AsNoTracking().ToListAsync(cancellationToken);
}
