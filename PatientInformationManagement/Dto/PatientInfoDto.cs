using PatientInformationManagement.Models;
using System.ComponentModel.DataAnnotations;

namespace PatientInformationManagement.Dto
{
    public class PatientInfoDto
    {
        public int ID { get; set; }

        [Required]
        public string PatientName { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

    }
}
