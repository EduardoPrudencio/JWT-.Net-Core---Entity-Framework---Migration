using System;

namespace AccessControl.BusinessRule.Models
{
    public abstract class Person
    {
        public Person()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

    }
}
