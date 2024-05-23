using System.Text.Json.Serialization;
using static PatientInformationManagement.Models.Epilepsy;

namespace PatientInformationManagement.Dto
{
    public class EpilepsyDto
    {
        public int Id { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public EpilepsyStatus Status { get; set; }
    }
}
