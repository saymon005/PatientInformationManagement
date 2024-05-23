using Microsoft.EntityFrameworkCore;
using PatientInformationManagement.Data;
using PatientInformationManagement.Interfaces;
using PatientInformationManagement.Models;

namespace PatientInformationManagement.Repository
{
    public class NCDRepository : INCDRepository
    {
        private readonly DataContext _dataContext;

        public NCDRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public bool CreateNCD(NCD ncd)
        {
            _dataContext.Add(ncd);
            return Save();
        }

        public bool DeleteNCD(NCD ncdId)
        {
           _dataContext.Remove(ncdId);
            return Save();
        }

        public NCD GetNCD(int id)
        {
            return _dataContext.NCDs.Where(n => n.ID == id).FirstOrDefault();
        }

        public NCD GetNCD(string name)
        {
            return _dataContext.NCDs.Where(n => n.NCDName == name).FirstOrDefault();
        }

        public ICollection<NCD> GetNCDs()
        {
            return _dataContext.NCDs.OrderBy(n => n.ID).ToList();
        }

        public bool NCDExist(int ncdId)
        {
            return _dataContext.NCDs.Any(n => n.ID == ncdId);
        }

        public bool Save()
        {
            var saved = _dataContext.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateNCD(NCD ncd)
        {
            _dataContext.Update(ncd);
            return Save();
        }
    }
}
