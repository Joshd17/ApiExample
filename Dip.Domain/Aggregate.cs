using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dip.Domain
{
    public abstract class Aggregate
    {
        public Guid Id { get; protected set; }
        [BsonIgnore]
        public ICollection<DomainEvent> DomainEvents = new List<DomainEvent>();

        protected Aggregate()
        {
            Id = Guid.NewGuid();
        }
    }
}
