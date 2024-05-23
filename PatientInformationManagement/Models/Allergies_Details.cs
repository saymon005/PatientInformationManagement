namespace PatientInformationManagement.Models
{
    public class Allergies_Details
    {
       // public int ID { get; set; }
        public int PatientID { get; set; }
        public int AllergiesID { get; set; }

        public PatientInfo Patient { get; set; }
        public Allergies Allergies { get; set; }
    }
}
