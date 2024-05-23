using System.ComponentModel.DataAnnotations;

namespace PatientInformationManagement.Models
{
    public class DiseaseInfo
    {
        public int ID { get; set; }

        [Required]
        public string DiseaseName { get; set; }
    }
}
