using Users.Domain.Primitives;

namespace Users.Domain.Entities;

public class Country : MasterEntity<Guid>
{
    public ICollection<City> Cities { get; } = [];
}
