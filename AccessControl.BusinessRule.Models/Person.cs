using System;

namespace AccessControl.BusinessRule.Models
{
    public abstract class Person
    {
        public Person()
        {
            Id = Guid.NewGuid().ToString().ToLower();
        }

        public string Id { get; set; }

    }
}
