using GenericRepository;
using System;

namespace Domain
{
    public abstract class BaseEntity : IEntity
    {
        public BaseEntity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
    }
}
