﻿using App.Core.Consts.SystemBase;
using Newtonsoft.Json;

namespace App.Core.Models.ClinicModules.NutritionalImprovementsModules.DTO
{
    public class NutritionalImprovementAddOrUpdateDTO
    {
        public Guid nutritionalImprovementToken { get; set; }
        public decimal patientHeightInCm { get; set; }
        public decimal patientWeightInKg { get; set; }
        public Guid userPatientToken { get; set; }
        public string? fullCode { get; set; }

        [JsonIgnore]
        public EnumActivationType activationType { get; set; }
    }
}