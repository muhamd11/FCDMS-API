using App.Core.Consts.GeneralModels;

namespace App.Core.Models.UsersModule._01._1_UserTypes.UserEmployee.ViewModel
{
    public class UserEmployeeInfo
    {
        public EnumGenderType userGender { get; set; }

        public string? userNationality { get; set; }

        public string? userNationalId { get; set; }
    }
}