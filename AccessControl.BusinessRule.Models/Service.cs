﻿using System.Collections.Generic;

namespace AccessControl.BusinessRule.Models
{
    public class Service
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<ServiceProfessional> ServiceProfessional { get; set; }

    }
}
