using System.ComponentModel.DataAnnotations;

namespace PatientInformation.Models
{
    public class PatientInfo
    {
        public int ID { get; set; }
        [Required]
        public string PatientName { get; set; }

        [Required]
        public string DiseasesName { get; set; }

        [Required]
        public bool Epilepsy { get; set; }

        public List<string> OtherNCDs { get; set; } = new List<string>();

        public List<string> Allergies { get; set; } = new List<string>();
    }
}
