using PatientInformationManagement.Data;
using PatientInformationManagement.Interfaces;
using PatientInformationManagement.Models;

namespace PatientInformationManagement.Repository
{
    public class EpilepsyRepository : IEpilepsyRepository
    {
        private readonly DataContext _dataContext;

        public EpilepsyRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public bool EpilepsyExists(int epilepsyId)
        {
            return _dataContext.Epilespsies.Any(e => e.Id == epilepsyId);
        }

        public ICollection<Epilepsy> GetEpilepsies()
        {
            return _dataContext.Epilespsies.OrderBy(e => e.Id).ToList();
        }

        public Epilepsy GetEpilepsy(int id)
        {
            return _dataContext.Epilespsies.Where(e => e.Id == id).FirstOrDefault();
        }
    }
}
