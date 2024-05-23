using Microsoft.EntityFrameworkCore;
using PatientInformationManagement.Data;
using PatientInformationManagement.Interfaces;
using PatientInformationManagement.Models;

namespace PatientInformationManagement.Repository
{
    public class PatientInfoRepository : IPatientInfoRepository
    {
        private readonly DataContext _dataContext;

        public PatientInfoRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public ICollection<PatientInfo> GetPatientsByNCDId(int ncdId)
        {
            return _dataContext.NCD_Details
                .Where(n => n.NCDID == ncdId)
                .Select(p => p.Patient)
                .ToList();
        }

        public ICollection<NCD> GetNCDsByPatientId(int patientId)
        {
            return _dataContext.NCD_Details
                .Where(p => p.PatientID == patientId)
                .Select(n => n.NCD)
                .ToList();
        }


        public PatientInfo GetPatientInfo(int id)
        {
            return _dataContext.Patients.Where(al => al.ID == id).FirstOrDefault();
        }

        public PatientInfo GetPatientInfo(string name)
        {
            return _dataContext.Patients.Where(al => al.PatientName == name).FirstOrDefault();
        }

        public ICollection<PatientInfo> GetPatientInfos()
        {
            return _dataContext.Patients.OrderBy(p => p.ID).ToList();
        }

        public bool PatientInfoExist(int patientinfoId)
        {
            return _dataContext.Patients.Any(al => al.ID == patientinfoId);
        }

        public ICollection<PatientInfo> GetPatientsByAllergiesId(int allergiesId)
        {
            return _dataContext.Allergies_Details
                .Where(a => a.AllergiesID == allergiesId)
                .Select(p => p.Patient)
                .ToList();
        }


        public ICollection<Allergies> GetAllergiesByPatientId(int patientId)
        {
            return _dataContext.Allergies_Details
                .Where(p => p.PatientID == patientId)
                .Select(a => a.Allergies)
                .ToList();
        }

        public bool CreatePatientInfo(int ncdId, int allergyId, PatientInfo patientInfo)
        {
            var ncd_detailsEntity = _dataContext.NCDs.Where(n => n.ID == ncdId).FirstOrDefault();
            var allergies_detailsEntity = _dataContext.Allergies.Where(a => a.ID == allergyId).FirstOrDefault();

            var ncd_details = new NCD_Details()
            {
                NCD = ncd_detailsEntity,
                Patient = patientInfo,
            };

            _dataContext.Add(ncd_details);

            var allergies_details = new Allergies_Details()
            {
                Allergies = allergies_detailsEntity,
                Patient = patientInfo,
            };

            _dataContext.Add(allergies_details);

            _dataContext.Add(patientInfo);

            return Save();
        }

        public bool Save()
        {
            var saved = _dataContext.SaveChanges();
            return saved > 0 ? true: false;
        }

        public bool UpdatePatientInfo(int ncdId, int allergyId, PatientInfo patientInfo)
        {
            _dataContext.Update(patientInfo);
            return Save();
        }

        public bool DeletePatientInfo(PatientInfo patientInfo)
        {
            _dataContext.Remove(patientInfo);
            return Save();
        }
    }
}
