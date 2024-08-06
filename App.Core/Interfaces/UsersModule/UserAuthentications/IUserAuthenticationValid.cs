﻿using App.Core.Interfaces.General.Scrutor;
using App.Core.Models.General.LocalModels;
using App.Core.Models.UsersModule._01._2_UserAuthentications.LoginModule.DTO;
using App.Core.Models.UsersModule._01._2_UserAuthentications.SignUpModule.DTO;

namespace App.Core.Interfaces.UsersModule.UserAuthentications
{
    public interface IUserAuthenticationValid : ITransientService
    {
        BaseValid IsValidLogin(UserLoginDto inputModel);
        BaseValid IsValidSginUp(UserSignUpDto inputModel);
    }
}