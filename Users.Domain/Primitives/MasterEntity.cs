﻿namespace Users.Domain.Primitives;

public abstract class MasterEntity<TId> : Entity<TId> where TId : IEquatable<TId>
{
    public string Name { get; set; } = default!;
}

