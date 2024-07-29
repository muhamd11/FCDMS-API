using App.Core.Models.ClinicModules.NutritionalImprovementsModules;
using App.Core.Models.ClinicModules.NutritionalImprovementsModules.DTO;
using App.Core.Models.ClinicModules.OperationsModules;
using App.Core.Models.ClinicModules.OperationsModules.DTO;
using AutoMapper;

namespace Api.MappingProfiles.ClinicModules
{
    public class ClinicModulesProfiles : Profile
    {
        public ClinicModulesProfiles()
        {
            CreateMap<Operation, OperationAddOrUpdateDTO>().ReverseMap();
            CreateMap<NutritionalImprovement, NutritionalImprovementAddOrUpdateDTO>().ReverseMap();
        }
    }
}