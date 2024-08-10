using Api.Controllers.SystemBase.BaseEntitys;
using Api.Controllers.UsersModule.Users;
using App.Core.Models.ClinicModules.MedicalHistoriesModules;
using App.Core.Models.ClinicModules.MedicalHistoriesModules.ViewModel;
using App.Core.Models.ClinicModules.VisitsModules;
using System.Linq.Expressions;

namespace Api.Controllers.SystemBase.MedicalHistories
{
    public static class MedicalHistoriesAdaptor
    {
        public static Expression<Func<MedicalHistory, MedicalHistoryInfo>> SelectExpressionMedicalHistoryInfo(bool includeUserPatientInfoData = false)
        {
            return medicalHistory => new MedicalHistoryInfo
            {
                medicalHistoryToken = medicalHistory.medicalHistoryToken,
                patientBloodPressureMeasurement = medicalHistory.patientBloodPressureMeasurement,
                patientSugarMeasurement = medicalHistory.patientSugarMeasurement,
                patientThyroidSensitivityMeasurement = medicalHistory.patientThyroidSensitivityMeasurement,
                userPatientInfo = includeUserPatientInfoData ? UsersAdaptor.SelectExpressionUserInfo(medicalHistory.userPatientData) : null,
                fullCode = medicalHistory.fullCode,
                activationType = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(medicalHistory).activationType,
                updatedDateTime = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(medicalHistory).updatedDateTime,
                createdDateTime = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(medicalHistory).createdDateTime,
            };
        }

        public static Expression<Func<MedicalHistory, MedicalHistoryInfoDetails>> SelectExpressionMedicalHistoryInfoDetails()
        {
            return medicalHistory => new MedicalHistoryInfoDetails
            {
                medicalHistoryToken = medicalHistory.medicalHistoryToken,
                patientBloodPressureMeasurement = medicalHistory.patientBloodPressureMeasurement,
                patientSugarMeasurement = medicalHistory.patientSugarMeasurement,
                patientThyroidSensitivityMeasurement = medicalHistory.patientThyroidSensitivityMeasurement,
                fullCode = medicalHistory.fullCode,
                activationType = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(medicalHistory).activationType,
                updatedDateTime = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(medicalHistory).updatedDateTime,
                createdDateTime = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(medicalHistory).createdDateTime,
            };
        }

        public static MedicalHistoryInfo SelectExpressionMedicalHistoryInfo(MedicalHistory medicalHistory)
        {
            if (medicalHistory == null)
                return null;

            return new MedicalHistoryInfo
            {
                medicalHistoryToken = medicalHistory.medicalHistoryToken,
                patientBloodPressureMeasurement = medicalHistory.patientBloodPressureMeasurement,
                patientSugarMeasurement = medicalHistory.patientSugarMeasurement,
                patientThyroidSensitivityMeasurement = medicalHistory.patientThyroidSensitivityMeasurement,
                fullCode = medicalHistory.fullCode,
                activationType = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(medicalHistory).activationType,
                updatedDateTime = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(medicalHistory).updatedDateTime,
                createdDateTime = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(medicalHistory).createdDateTime,
            };
        }

        public static MedicalHistoryInfoDetails SelectExpressionMedicalHistoryInfoDetails(MedicalHistory medicalHistory)
        {
            if (medicalHistory == null)
                return null;

            return new MedicalHistoryInfoDetails
            {
                medicalHistoryToken = medicalHistory.medicalHistoryToken,
                patientBloodPressureMeasurement = medicalHistory.patientBloodPressureMeasurement,
                patientSugarMeasurement = medicalHistory.patientSugarMeasurement,
                patientThyroidSensitivityMeasurement = medicalHistory.patientThyroidSensitivityMeasurement,
                fullCode = medicalHistory.fullCode,
                activationType = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(medicalHistory).activationType,
                updatedDateTime = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(medicalHistory).updatedDateTime,
                createdDateTime = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(medicalHistory).createdDateTime,
            };
        }
    }
}