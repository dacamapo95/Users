using Users.Domain.Primitives;

namespace Users.Domain.Entities;

public class Address : AuditableEntity<Guid>
{
    public Guid UserId { get; set; } = default!;

    public string Street { get; set; } = default!;

    public Guid CityId { get; set; } = default!;

    public string? ZipCode { get; set; }

    public User User { get; set; }

    public City City { get; set; }

    private Address()
    {
    }

    private Address(string street, Guid cityId, string? zipCode)
    {
        Street = street;
        CityId = cityId;
        ZipCode = zipCode;
    }

    public static Address Create(string street, Guid cityId, string? zipCode) =>
        new(street, cityId, zipCode);
}