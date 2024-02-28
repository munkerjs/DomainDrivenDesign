using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Domain.Abstractions
{
    public abstract class BaseEntity
    {
        public Guid Id { get; init; }
        public BaseEntity(Guid id)
        {
            Id = id;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj is not BaseEntity entity)
            {
                return false;
            }

            if(obj.GetType() != GetType())
            {
                return false;
            }

            return base.Equals(Id);
        }
    }
}
