using System.ComponentModel.DataAnnotations;

namespace PatientInformationManagement.Models
{
    public class Allergies
    {
        public int ID { get; set; }

        [Required]
        public string AllergyName { get; set; }
        public ICollection<Allergies_Details> Allergies_Details { get; set; }
    }
}
