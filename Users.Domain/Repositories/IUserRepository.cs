using Users.Domain.Entities;

namespace Users.Domain.Repositories;

public interface IUserRepository
{
    void Add(User user);

    void Update(User user);

    void Remove(User user);

    Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<List<User>> GetAsync(CancellationToken cancellationToken = default);

    Task<bool> ExistsByUserNameAsync(string userName, CancellationToken cancellationToken = default);

    Task<bool> ExistsByEmailAsync(string email, CancellationToken cancellationToken = default);

    Task<User?> GetUserWithAddresses(Guid id, CancellationToken cancellationToken = default);
}
