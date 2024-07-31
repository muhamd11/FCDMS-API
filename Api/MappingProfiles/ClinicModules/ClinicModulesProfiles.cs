using App.Core.Models.ClinicModules.MedicalHistoriesModules;
using App.Core.Models.ClinicModules.MedicalHistoriesModules.DTO;
using App.Core.Models.ClinicModules.NutritionalImprovementsModules;
using App.Core.Models.ClinicModules.NutritionalImprovementsModules.DTO;
using App.Core.Models.ClinicModules.OperationsModules;
using App.Core.Models.ClinicModules.OperationsModules.DTO;
using App.Core.Models.ClinicModules.VisitsModules;
using App.Core.Models.ClinicModules.VisitsModules.DTO;
using AutoMapper;

namespace Api.MappingProfiles.ClinicModules
{
    public class ClinicModulesProfiles : Profile
    {
        public ClinicModulesProfiles()
        {
            CreateMap<Operation, OperationAddOrUpdateDTO>().ReverseMap();
            CreateMap<NutritionalImprovement, NutritionalImprovementAddOrUpdateDTO>().ReverseMap();
            CreateMap<Visit, VisitAddOrUpdateDTO>().ReverseMap();
            CreateMap<MedicalHistory, MedicalHistoryAddOrUpdateDTO>().ReverseMap();
        }
    }
}