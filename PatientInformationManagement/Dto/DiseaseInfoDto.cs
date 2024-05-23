using System.ComponentModel.DataAnnotations;

namespace PatientInformationManagement.Dto
{
    public class DiseaseInfoDto
    {
        public int ID { get; set; }

        [Required]
        public string DiseaseName { get; set; }
    }
}
