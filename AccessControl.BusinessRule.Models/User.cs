using System;

namespace AccessControl.BusinessRule.Models
{
    public class User : Person
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
