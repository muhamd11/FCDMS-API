namespace App.Core.Models.ClinicModules.VisitsModules.DTO
{
    public class VisitAddOrUpdateDTO
    {
        public Guid visitToken { get; set; }
        public string fullCode { get; set; }

        public DateOnly lastPeriodDate { get; set; }

        public DateOnly expectedDateOfBirth { get; set; }

        public string userPatientComplaining { get; set; }

        public int numberOfChildren { get; set; }

        public string medications { get; set; }

        public string generalNotes { get; set; }

        public FetalInformation fetalInformations { get; set; }

        public Guid userPatientToken { get; set; }
    }
}