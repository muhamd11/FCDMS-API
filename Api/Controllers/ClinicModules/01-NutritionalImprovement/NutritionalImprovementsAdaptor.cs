using Api.Controllers.SystemBase.BaseEntitys;
using Api.Controllers.UsersModule.Users;
using App.Core.Models.ClinicModules.NutritionalImprovementsModules;
using App.Core.Models.ClinicModules.NutritionalImprovementsModules.ViewModel;
using System.Linq.Expressions;

namespace Api.Controllers.SystemBase.NutritionalImprovements
{
    public static class NutritionalImprovementsAdaptor
    {
        public static Expression<Func<NutritionalImprovement, NutritionalImprovementInfo>> SelectExpressionNutritionalImprovementInfo(bool includeUserPatientInfoData = false)
        {
            return nutritionalImprovement => new NutritionalImprovementInfo
            {
                nutritionalImprovementToken = nutritionalImprovement.nutritionalImprovementToken,
                patientHeightInCm = nutritionalImprovement.patientHeightInCm,
                patientWeightInKg = nutritionalImprovement.patientWeightInKg,
                patientBmr = nutritionalImprovement.patientBmr,
                userPatientInfo = includeUserPatientInfoData ? UsersAdaptor.SelectExpressionUserInfo(nutritionalImprovement.userPatientData) : null,
                fullCode = nutritionalImprovement.fullCode,
                activationType = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(nutritionalImprovement).activationType,
                updatedDateTime = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(nutritionalImprovement).updatedDateTime,
                createdDateTime = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(nutritionalImprovement).createdDateTime,
            };
        }

        public static Expression<Func<NutritionalImprovement, NutritionalImprovementInfoDetails>> SelectExpressionNutritionalImprovementInfoDetails()
        {
            return nutritionalImprovement => new NutritionalImprovementInfoDetails
            {
                nutritionalImprovementToken = nutritionalImprovement.nutritionalImprovementToken,
                patientHeightInCm = nutritionalImprovement.patientHeightInCm,
                patientWeightInKg = nutritionalImprovement.patientWeightInKg,
                patientBmr = nutritionalImprovement.patientBmr,
                fullCode = nutritionalImprovement.fullCode,
                activationType = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(nutritionalImprovement).activationType,
                updatedDateTime = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(nutritionalImprovement).updatedDateTime,
                createdDateTime = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(nutritionalImprovement).createdDateTime,
            };
        }

        public static NutritionalImprovementInfo SelectExpressionNutritionalImprovementInfo(NutritionalImprovement nutritionalImprovement)
        {
            if (nutritionalImprovement == null)
                return null;

            return new NutritionalImprovementInfo
            {
                nutritionalImprovementToken = nutritionalImprovement.nutritionalImprovementToken,
                patientHeightInCm = nutritionalImprovement.patientHeightInCm,
                patientWeightInKg = nutritionalImprovement.patientWeightInKg,
                patientBmr = nutritionalImprovement.patientBmr,
                fullCode = nutritionalImprovement.fullCode,
                activationType = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(nutritionalImprovement).activationType,
                updatedDateTime = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(nutritionalImprovement).updatedDateTime,
                createdDateTime = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(nutritionalImprovement).createdDateTime,
            };
        }

        public static NutritionalImprovementInfoDetails SelectExpressionNutritionalImprovementInfoDetails(NutritionalImprovement nutritionalImprovement)
        {
            if (nutritionalImprovement == null)
                return null;

            return new NutritionalImprovementInfoDetails
            {
                nutritionalImprovementToken = nutritionalImprovement.nutritionalImprovementToken,
                patientHeightInCm = nutritionalImprovement.patientHeightInCm,
                patientWeightInKg = nutritionalImprovement.patientWeightInKg,
                patientBmr = nutritionalImprovement.patientBmr,
                fullCode = nutritionalImprovement.fullCode,
                activationType = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(nutritionalImprovement).activationType,
                updatedDateTime = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(nutritionalImprovement).updatedDateTime,
                createdDateTime = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(nutritionalImprovement).createdDateTime,
            };
        }
    }
}