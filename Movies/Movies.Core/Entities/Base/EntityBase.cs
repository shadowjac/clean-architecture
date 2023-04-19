﻿namespace Movies.Core.Entities.Base
{
    public class EntityBase<TId> : IEntityBase<TId>
    {
        public virtual TId Id { get; protected set; }
    }
}