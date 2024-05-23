
using System.ComponentModel.DataAnnotations;

namespace PatientInformationManagement.Models
{
    public class NCD
    {
        public int ID { get; set; }

        [Required]
        public string NCDName { get; set;}

        public ICollection<NCD_Details> NCD_Details { get; set; }
    }
}
