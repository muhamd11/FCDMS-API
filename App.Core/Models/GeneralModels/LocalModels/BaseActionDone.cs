using App.Core.Consts.GeneralModels;
using App.Core.Resources.General;

namespace App.Core.Models.General.LocalModels
{
    public class BaseActionDone<T>
    {
        public EnumStatus Status { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public static BaseActionDone<T> GenrateBaseActionDone(int countRowEffectInDB, T data)
        {
            return new BaseActionDone<T>()
            {
                Status = countRowEffectInDB > 0 ? EnumStatus.success : EnumStatus.error,
                Message = countRowEffectInDB > 0 ? GeneralMessages.actionSuccess : GeneralMessages.errorActionFailed,
                Data = data,
            };
        }
    }
}