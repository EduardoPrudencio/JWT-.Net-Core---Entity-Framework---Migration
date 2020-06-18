using System.Collections.Generic;

namespace AccessControl.BusinessRule.Models
{
    public class Professional : Person
    {
        public List<ServiceProfessional> ServiceProfessional { get; set; }

    }
}
