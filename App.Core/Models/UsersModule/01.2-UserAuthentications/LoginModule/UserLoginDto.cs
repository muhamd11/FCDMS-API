using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Models.UsersModule._01._2_UserAuthentications.LoginModule
{
    public class UserLoginDto
    {
        //It Will be usernameLogin or userPhoneNumber or userEmail
        public string userLoginText { get; set; }

        public string userPassword { get; set; }
    }
}
