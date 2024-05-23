using Microsoft.EntityFrameworkCore;
using PatientInformationManagement.Data;
using PatientInformationManagement.Interfaces;
using PatientInformationManagement.Models;

namespace PatientInformationManagement.Repository
{
    public class DiseaseInfoRepository : IDiseaseInfoRepository
    {
        private readonly DataContext _dataContext;

        public DiseaseInfoRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public bool CreateDiseaseInfo(DiseaseInfo diseaseInfo)
        {
            _dataContext.Add(diseaseInfo);
            return Save();
        }

        public bool DeleteDiseaseInfo(DiseaseInfo deiseaseInfo)
        {
            _dataContext.Remove(deiseaseInfo);
            return Save();
        }

        public bool DiseaseInfoExist(int diseaseInfoId)
        {
            return _dataContext.Diseases.Any(d => d.ID == diseaseInfoId);
        }

        public DiseaseInfo GetDiseaseInfo(int id)
        {
            return _dataContext.Diseases.Where(d => d.ID == id).FirstOrDefault();
        }

        public DiseaseInfo GetDiseaseInfo(string name)
        {
            return _dataContext.Diseases.Where(d => d.DiseaseName == name).FirstOrDefault();
        }

        public ICollection<DiseaseInfo> GetDiseaseInfos()
        {
            return _dataContext.Diseases.OrderBy(d => d.ID).ToList();
        }

        public bool Save()
        {
            var saved = _dataContext.SaveChanges();
            return saved>0 ? true : false;
        }

        public bool UpdateDiseaseInfo(DiseaseInfo diseaseInfo)
        {
            _dataContext.Update(diseaseInfo);
            return Save();
        }
    }
}
