﻿using App.Core.Interfaces.General.Scrutor;
using App.Core.Models.General.LocalModels;
using App.Core.Models.Users;
using App.Core.Models.UsersModule._01._2_UserAuthentications.ForgetPasswordModules.DTO;
using App.Core.Models.UsersModule._01._2_UserAuthentications.ForgetPasswordModules.ViewModel;
using App.Core.Models.UsersModule._01._2_UserAuthentications.LoginModule.DTO;
using App.Core.Models.UsersModule._01._2_UserAuthentications.LoginModule.ViewModel;
using App.Core.Models.UsersModule._01._2_UserAuthentications.SignUpModule.DTO;

namespace App.Core.Interfaces.UsersModule.UserAuthentications
{
    public interface IUserAuthenticationServices : ITransientService
    {
        Task<UserLoginInfo> Login(UserLoginDto inputModel);

        Task<UserInfo> Signup(UserSignUpDto inputModel);

        Task<BaseActionDone<CheckUserForOtpInfo>> CheckUserForOtp(CheckUserForOtpDTO inputModel);

        Task<VerifyOtpInfo> VerifyOtp(VerifyOtpDTO inputModel);

        Task<BaseActionDone<ChangePasswordInfo>> ChangePassword(ChangePasswordDTO inputModel);
    }
}