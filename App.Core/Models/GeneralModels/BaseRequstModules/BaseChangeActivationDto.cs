using App.Core.Consts.SystemBase;


namespace App.Core.Models.GeneralModels.BaseRequstModules
{
    public class BaseChangeActivationDto
    {
        public Guid elementToken { get; set; }
        public EnumActivationType activationType { get; set; }
    }
}
