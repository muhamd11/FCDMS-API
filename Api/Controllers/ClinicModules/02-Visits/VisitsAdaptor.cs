using Api.Controllers.SystemBase.BaseEntitys;
using Api.Controllers.UsersModule.Users;
using App.Core.Models.ClinicModules.VisitsModules;
using System.Linq.Expressions;

namespace Api.Controllers.SystemBase.Visits
{
    public static class VisitsAdaptor
    {
        public static Expression<Func<Visit, VisitInfo>> SelectExpressionVisitInfo(bool includeUserPatientInfoData = false)
        {
            return visit => new VisitInfo
            {
                visitToken = visit.visitToken,
                expectedDateOfBirth = visit.expectedDateOfBirth,
                fetalInformations = visit.fetalInformations,
                lastPeriodDate = visit.lastPeriodDate,
                numberOfChildren = visit.numberOfChildren,
                medications = visit.medications,
                generalNotes = visit.generalNotes,
                userPatientComplaining = visit.userPatientComplaining,
                userPatientInfo = includeUserPatientInfoData ? UsersAdaptor.SelectExpressionUserInfo(visit.userPatientData) : null,
                fullCode = visit.fullCode,
                activationType = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(visit).activationType,
                updatedDateTime = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(visit).updatedDateTime,
                createdDateTime = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(visit).createdDateTime,
            };
        }

        public static Expression<Func<Visit, VisitInfoDetails>> SelectExpressionVisitInfoDetails()
        {
            return visit => new VisitInfoDetails
            {
                visitToken = visit.visitToken,
                expectedDateOfBirth = visit.expectedDateOfBirth,
                fetalInformations = visit.fetalInformations,
                lastPeriodDate = visit.lastPeriodDate,
                numberOfChildren = visit.numberOfChildren,
                medications = visit.medications,
                generalNotes = visit.generalNotes,
                userPatientComplaining = visit.userPatientComplaining,
                fullCode = visit.fullCode,
                activationType = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(visit).activationType,
                updatedDateTime = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(visit).updatedDateTime,
                createdDateTime = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(visit).createdDateTime,
            };
        }

        public static VisitInfo SelectExpressionVisitInfo(Visit visit)
        {
            if (visit == null)
                return null;

            return new VisitInfo
            {
                visitToken = visit.visitToken,
                expectedDateOfBirth = visit.expectedDateOfBirth,
                fetalInformations = visit.fetalInformations,
                lastPeriodDate = visit.lastPeriodDate,
                numberOfChildren = visit.numberOfChildren,
                medications = visit.medications,
                generalNotes = visit.generalNotes,
                userPatientComplaining = visit.userPatientComplaining,
                fullCode = visit.fullCode,
                activationType = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(visit).activationType,
                updatedDateTime = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(visit).updatedDateTime,
                createdDateTime = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(visit).createdDateTime,
            };
        }

        public static VisitInfoDetails SelectExpressionVisitInfoDetails(Visit visit)
        {
            if (visit == null)
                return null;

            return new VisitInfoDetails
            {
                visitToken = visit.visitToken,
                expectedDateOfBirth = visit.expectedDateOfBirth,
                fetalInformations = visit.fetalInformations,
                lastPeriodDate = visit.lastPeriodDate,
                numberOfChildren = visit.numberOfChildren,
                medications = visit.medications,
                generalNotes = visit.generalNotes,
                userPatientComplaining = visit.userPatientComplaining,
                fullCode = visit.fullCode,
                activationType = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(visit).activationType,
                updatedDateTime = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(visit).updatedDateTime,
                createdDateTime = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(visit).createdDateTime,
            };
        }
    }
}