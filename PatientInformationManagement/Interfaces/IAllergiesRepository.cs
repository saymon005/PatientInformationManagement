using PatientInformationManagement.Models;

namespace PatientInformationManagement.Interfaces
{
    public interface IAllergiesRepository
    {
        ICollection<Allergies> GetAllergies();
        Allergies GetAllergy(int id);
        Allergies GetAllergy(string name);

        bool AllergiesExist(int allergyID);
        bool CreateAllergies(Allergies allergies);
        bool UpdateAllergies(Allergies allergies);
        bool DeleteAllergies(Allergies allergies);
        bool Save();

    }
}
