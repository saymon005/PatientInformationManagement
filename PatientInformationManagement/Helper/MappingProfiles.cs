using AutoMapper;
using PatientInformationManagement.Dto;
using PatientInformationManagement.Models;

namespace PatientInformationManagement.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Allergies, AllergiesDto>();
            CreateMap<AllergiesDto,Allergies>();
            CreateMap<PatientInfo, PatientInfoDto>();
            CreateMap<PatientInfoDto,PatientInfo>();
            CreateMap<DiseaseInfo, DiseaseInfoDto>();
            CreateMap<DiseaseInfoDto,DiseaseInfo>();
            CreateMap<NCD, NCDDto>();
            CreateMap<NCDDto,NCD>();
            CreateMap<Epilepsy, EpilepsyDto>();
            CreateMap<EpilepsyDto,Epilepsy>();
        }
    }
}
