﻿using App.Core.Consts.ClinicModules;
using App.Core.Models.ClinicModules.OperationsModules.ViewModel;

namespace App.Core.Models.UsersModule._01._1_UserTypes._02_UserClientData.ViewModel
{
    public class UserPatientInfo
    {
        public EnumBloodType userPatientBloodType { get; set; }
        public int userPatientChildrenCount { get; set; }
        public int userPatientAge { get; set; }
    }
}