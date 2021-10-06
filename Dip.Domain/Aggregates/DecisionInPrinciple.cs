
using System.Collections.Generic;

namespace Dip.Domain.Aggregates
{
    public class DecisionInPrinciple : Aggregate
    {
        public DecisionInPrinciple(string name)
        {
            Name = name;
            Questions = new List<Question>();
        }

        public string Name { get; private set; }

        public IEnumerable<Question> Questions { get; private set; }
    }
}

