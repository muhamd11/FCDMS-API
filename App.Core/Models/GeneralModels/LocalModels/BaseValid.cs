using App.Core.Consts.GeneralModels;

namespace App.Core.Models.General.LocalModels
{
    public class BaseValid
    {
        public EnumStatus Status { get; set; }
        public string Message { get; set; }

        public static BaseValid createBaseValid(string message, EnumStatus status)
        {
            return new BaseValid
            {
                Status = status,
                Message = message
            };
        }

        public static BaseValid createBaseValidError(string message)
        {
            return new BaseValid
            {
                Status = EnumStatus.error,
                Message = message
            };
        }
    }
}