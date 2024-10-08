﻿using App.Core.Models.UsersModule._01_1_UserTypes;
using App.Core.Models.UsersModule._01_1_UserTypes._02_UserPatientData;

namespace App.Core.Models.UsersModule._01._2_UserAuthentications.SignUpModule.DTO
{
    public class UserSignUpDto
    {
        public string? userName { get; set; }
        public string? userEmail { get; set; }
        public string? userPhone { get; set; }
        public string? userPhoneCC { get; set; }
        public string? userPhoneCCName { get; set; }
        public string? userLoginName { get; set; }
        public string? userPassword { get; set; }
        public UserProfile? userProfileData { get; set; }
        public UserPatient? userPatientData { get; set; }
    }
}