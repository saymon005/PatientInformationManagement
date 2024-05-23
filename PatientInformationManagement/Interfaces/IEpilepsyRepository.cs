using PatientInformationManagement.Models;

namespace PatientInformationManagement.Interfaces
{
    public interface IEpilepsyRepository
    {
        ICollection<Epilepsy> GetEpilepsies();
        Epilepsy GetEpilepsy(int id);
        
        bool EpilepsyExists(int epilepsyId);
    }
}
