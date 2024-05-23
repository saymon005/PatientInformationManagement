using System.Text.Json.Serialization;

namespace PatientInformationManagement.Models
{
    public class Epilepsy
    {
        public int Id { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public EpilepsyStatus Status { get; set; }

        public enum EpilepsyStatus
        {
            Yes,
            No
        }
    }
}
