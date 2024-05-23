using Microsoft.EntityFrameworkCore;
using PatientInformationManagement.Data;
using PatientInformationManagement.Interfaces;
using PatientInformationManagement.Models;

namespace PatientInformationManagement.Repository
{
    public class AllergiesRepository : IAllergiesRepository
    {
        private readonly DataContext _dataContext;

        public AllergiesRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public bool AllergiesExist(int allergyID)
        {
            return _dataContext.Allergies.Any(al => al.ID == allergyID);
        }

        public bool CreateAllergies(Allergies allergies)
        {
            _dataContext.Add(allergies);
            return Save();
        }

        public bool DeleteAllergies(Allergies allergies)
        {
            _dataContext.Remove(allergies);
            return Save();
        }

        public ICollection<Allergies> GetAllergies()
        {
            return _dataContext.Allergies.OrderBy(al => al.ID).ToList();
        }

        public Allergies GetAllergy(int id)
        {
           return _dataContext.Allergies.Where(al => al.ID == id).FirstOrDefault();
        }

        public Allergies GetAllergy(string name)
        {
            return _dataContext.Allergies.Where(al => al.AllergyName == name).FirstOrDefault();
        }

        public bool Save()
        {
            var saved = _dataContext.SaveChanges();
            return saved > 0 ? true: false;
        }

        public bool UpdateAllergies(Allergies allergies)
        {
            _dataContext.Update(allergies);
            return Save();
        }
    }
}
