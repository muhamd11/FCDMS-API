using App.Core.Models.SystemBase.BaseClass;
using App.Core.Models.Users;

namespace App.Core.Models.ClinicModules.NutritionalImprovementsModules.ViewModel
{
    public class NutritionalImprovementInfo : BaseEntityInfo
    {
        public Guid nutritionalImprovementToken { get; set; }
        public decimal patientHeightInCm { get; set; }
        public decimal patientWeightInKg { get; set; }
        public decimal patientBmr { get; set; }
        public UserInfo? userPatientInfo { get; set; }
    }
}