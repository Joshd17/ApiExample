
using System;
using System.Collections.Generic;

namespace Dip.Domain.Aggregates
{
    public class DecisionInPrinciple : Aggregate
    {
        private DecisionInPrinciple()
        {

        }
        public DecisionInPrinciple(string name)
        {
            Name = name;
            Questions = new List<Question>() { new Question{Answer = new Answer(){Text = "Some text"}, Title = "A title"}};
            DomainEvents.Add(new DipCreatedEvent{DecisionInPrinciple = this, ObjectId = Id});
        }

        public string Name { get; private set; }

        public IEnumerable<Question> Questions { get; private set; }
    }

    public class DipCreatedEvent : CreatedDomainEvent
    {
        public DecisionInPrinciple DecisionInPrinciple { get; set; }
    }

    public class CreatedDomainEvent : DomainEvent
    {
        public Guid ObjectId { get; set; }
    }

}

