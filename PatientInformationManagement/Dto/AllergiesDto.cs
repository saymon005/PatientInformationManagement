using System.ComponentModel.DataAnnotations;

namespace PatientInformationManagement.Dto
{
    public class AllergiesDto
    {
        public int ID { get; set; }

        [Required]
        public string AllergyName { get; set; }
    }
}
