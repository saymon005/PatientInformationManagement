using PatientInformationManagement.Models;

namespace PatientInformationManagement.Interfaces
{
    public interface INCDRepository
    {
        ICollection<NCD> GetNCDs();

        NCD GetNCD(int id);
        NCD GetNCD(string name);
        bool NCDExist(int ncdId);

        bool CreateNCD(NCD ncd);
        bool UpdateNCD(NCD ncd);
        bool DeleteNCD(NCD ncdId);
        bool Save();
    }
}
