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

        protected Aggregate()
        {
            Id = Guid.NewGuid();
        }
    }
}
