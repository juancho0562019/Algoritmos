﻿namespace Domain.Common
{
    public abstract class BaseAuditableEntity<T> : BaseEntity<T> where T : notnull
    {
        public DateTimeOffset Created { get; set; }

        public string? CreatedBy { get; set; }

        public DateTimeOffset LastModified { get; set; }

        public string? LastModifiedBy { get; set; }
        public bool State { get; set; }
    }
}