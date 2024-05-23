namespace PatientInformationManagement.Models
{
    public class NCD_Details
    {
       // public int ID { get; set; }
        public int PatientID { get; set; }
        public int NCDID { get; set; }

        public PatientInfo Patient { get; set; }
        public NCD NCD { get; set; }
    }
}
