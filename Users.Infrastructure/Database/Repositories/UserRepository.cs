using Microsoft.EntityFrameworkCore;
using Users.Domain.Entities;
using Users.Domain.Repositories;

namespace Users.Infrastructure.Database.Repositories;

public sealed class UserRepository(ApplicationDbContext applicationDbContext) : IUserRepository
{
    private readonly ApplicationDbContext _context = applicationDbContext;

    public void Add(User user)
    {
        _context.Users.Add(user);
    }

    public void Remove(User user)
    {
        _context.Remove(user);
    }

    public void Update(User user)
    {
        _context.Update(user);
    }

    public async Task<bool> ExistsByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        return await _context.Users.AnyAsync(u => u.Email == email, cancellationToken);
    }

    public async Task<bool> ExistsByUserNameAsync(string userName, CancellationToken cancellationToken = default)
    {
       return await _context.Users.AnyAsync(u => u.UserName == userName, cancellationToken);
    }

    public async Task<List<User>> GetAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Users.AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Users.FindAsync(new object[] { id }, cancellationToken);
    }

    public async Task<User?> GetUserWithAddresses(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Users
            .Include(u => u.Addresses)
            .FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
    }
}
