namespace Users.Shared;

public record MasterEntityResponse<TId>(TId Id, string Name) where TId : IEquatable<TId>;
