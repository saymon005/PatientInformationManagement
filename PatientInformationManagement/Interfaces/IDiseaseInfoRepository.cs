using PatientInformationManagement.Models;

namespace PatientInformationManagement.Interfaces
{
    public interface IDiseaseInfoRepository
    {
        ICollection<DiseaseInfo> GetDiseaseInfos();

        DiseaseInfo GetDiseaseInfo(int id);
        DiseaseInfo GetDiseaseInfo(string name);

        bool DiseaseInfoExist(int diseaseInfoId);
        bool CreateDiseaseInfo(DiseaseInfo diseaseInfo);
        bool UpdateDiseaseInfo(DiseaseInfo diseaseInfo);
        bool DeleteDiseaseInfo(DiseaseInfo deiseaseInfo);
        bool Save();
    }
}
