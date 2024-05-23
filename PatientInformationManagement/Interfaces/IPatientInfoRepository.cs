using PatientInformationManagement.Models;

namespace PatientInformationManagement.Interfaces
{
    public interface IPatientInfoRepository
    {
        ICollection<PatientInfo> GetPatientInfos();

        PatientInfo GetPatientInfo(int id);
        PatientInfo GetPatientInfo(string name);

        ICollection<PatientInfo> GetPatientsByNCDId(int ncdId);
        ICollection<NCD> GetNCDsByPatientId(int patientId);

        ICollection<PatientInfo> GetPatientsByAllergiesId(int allergiesId);
        ICollection<Allergies> GetAllergiesByPatientId(int patientId);

        bool PatientInfoExist(int patientinfoId);
        bool CreatePatientInfo(int ncdId, int allergyId, PatientInfo patientInfo);
        bool UpdatePatientInfo(int ncdId, int allergyId, PatientInfo patientInfo);
        bool DeletePatientInfo(PatientInfo patientInfo);
        bool Save();
    }
}
