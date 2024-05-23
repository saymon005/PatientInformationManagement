using System.ComponentModel.DataAnnotations;

namespace PatientInformationManagement.Dto
{
    public class NCDDto
    {
        public int ID { get; set; }

        [Required]
        public string NCDName { get; set; }
    }
}
