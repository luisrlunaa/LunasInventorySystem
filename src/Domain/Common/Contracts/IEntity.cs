﻿namespace Luna.Core.Domain.Common.Contracts;

public interface IEntity
{
}

public interface IEntity<out TId> : IEntity
{
    TId Id { get; }
}