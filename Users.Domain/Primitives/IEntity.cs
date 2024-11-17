namespace Users.Domain.Primitives;

public interface IEntity<TId> where TId : IEquatable<TId>
{
    TId Id { get; set; }
}
