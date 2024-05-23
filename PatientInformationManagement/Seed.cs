using Microsoft.EntityFrameworkCore;
using PatientInformationManagement.Data;
using PatientInformationManagement.Models;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;

namespace PatientInformationManagement
{
    public class Seed
    {
        private readonly DataContext _dataContext;

        public Seed(DataContext context)
        {
            _dataContext = context;
        }

        public void SeedDataContext()
        {

            /* var patients = new List<PatientInfo>
                 {
                     new PatientInfo { PatientName = "Saymon Islam", Age = 30, Gender = "Male" },
                     new PatientInfo { PatientName = "Afifa Khanom", Age = 25, Gender = "Female" }
                 };

             _dataContext.Patients.AddRange(patients);
             _dataContext.SaveChanges();*/

            /* var ncds = new List<NCD>
                 {
                     new NCD { NCDName = "Asthma" },
                     new NCD { NCDName = "Cancer" }
                 };*/

            /* var allergies = new List<Allergies>
                 {
                     new Allergies { AllergyName = "Penicillin" },
                     new Allergies { AllergyName = "Peanuts" }
                 };

             //_dataContext.NCDs.AddRange(ncds);
             _dataContext.Allergies.AddRange(allergies);
             _dataContext.SaveChanges();*/
           if(!_dataContext.Epilespsies.Any())
            {
                var epilepsies = new List<Epilepsy>
                 {    new Epilepsy {Status = Epilepsy.EpilepsyStatus.Yes },
                      new Epilepsy {Status = Epilepsy.EpilepsyStatus.No }
                 };
                _dataContext.Epilespsies.AddRange(epilepsies);
                _dataContext.SaveChanges();
            }
            
            if (!_dataContext.Diseases.Any())
            {
                var diseases = new List<DiseaseInfo>
                {
                    new DiseaseInfo { DiseaseName = "Cancer" },
                    new DiseaseInfo { DiseaseName = "Asthma" }
                };

                _dataContext.Diseases.AddRange(diseases);
                _dataContext.SaveChanges();
            }


            if (!_dataContext.NCD_Details.Any())
            {

                var ncd_details = new List<NCD_Details>()
                {
                   new NCD_Details()
                   {
                       Patient = new PatientInfo()
                       {
                           PatientName = "Saymon Islam",
                           Age = 24,
                           Gender = "Male",

                           Allergies_Details = new List<Allergies_Details>()
                            {
                                 new Allergies_Details { Allergies = new Allergies() { AllergyName = "Food"}}
                            }
                       },

                       NCD = new NCD ()
                       {
                           NCDName = "Asthma"
                          
                       }
                       
                   }
                };

                
                _dataContext.NCD_Details.AddRange(ncd_details);
                _dataContext.SaveChanges();
            }

            if (!_dataContext.Allergies_Details.Any())
            {
                var allergiesDetails = new List<Allergies_Details>()
                {
                    new Allergies_Details()
                    {
                        Patient = new PatientInfo()
                       {
                           PatientName = "Saymon Islam",
                           Age = 24,
                           Gender = "Male",

                            NCD_Details = new List<NCD_Details>()
                            {
                                 new NCD_Details { NCD = new NCD() { NCDName = "Asthma"}}
                            }

                       },
                       Allergies = new Allergies() 
                       {
                           AllergyName = "Animals"
                       }
                    }
                };

                _dataContext.Allergies_Details.AddRange(allergiesDetails);
                _dataContext.SaveChanges();
            }
        }
    }
}
