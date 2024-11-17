using Users.Domain.Primitives;

namespace Users.Domain.Entities;

public class City : MasterEntity<Guid>
{
    public Guid CountryId { get; set; }

    public Country Country { get; set; }
}