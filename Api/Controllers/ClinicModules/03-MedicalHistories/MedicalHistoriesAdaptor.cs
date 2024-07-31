using Api.Controllers.SystemBase.BaseEntitys;
using Api.Controllers.UsersModule.Users;
using App.Core.Models.ClinicModules.MedicalHistoriesModules;
using App.Core.Models.ClinicModules.MedicalHistoriesModules.ViewModel;
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
                userPatientInfo = includeUserPatientInfoData == false ? null : UsersAdaptor.SelectExpressionUserInfo(medicalHistory.userPatientData),
                fullCode = medicalHistory.fullCode,
                isDeleted = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(medicalHistory).isDeleted,
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
                isDeleted = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(medicalHistory).isDeleted,
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
                isDeleted = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(medicalHistory).isDeleted,
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
                isDeleted = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(medicalHistory).isDeleted,
                updatedDateTime = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(medicalHistory).updatedDateTime,
                createdDateTime = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(medicalHistory).createdDateTime,
            };
        }
    }
}