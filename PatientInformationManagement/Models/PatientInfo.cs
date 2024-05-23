using System.ComponentModel.DataAnnotations;

namespace PatientInformationManagement.Models
{
    public class PatientInfo
    {
        public int ID { get; set; }

        [Required]
        public string PatientName { get; set;}

        public int Age { get; set; }

        public string Gender { get; set; }

        public ICollection<NCD_Details> NCD_Details { get; set; }
        public ICollection<Allergies_Details> Allergies_Details { get; set; }
    }
}
