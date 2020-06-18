namespace AccessControl.BusinessRule.Models
{
    public class ServiceProfessional
    {
        public int ServiceId { get; set; }

        public Service Service { get; set; }

        public string ProfessionalId { get; set; }
        public Professional Professional { get; set; }
    }
}
