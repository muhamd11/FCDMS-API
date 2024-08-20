using App.Core.Consts.GeneralModels;
using App.Core.Interfaces.General.Scrutor;
using App.Core.Models.General.LocalModels;

public interface IBaseActionResponse : ITransientService
{
    public Dictionary<string, object> CreateResponse<T>(BaseActionDone<T> inputModel, string moduleName);
    public Dictionary<string, object> CreateResponse(BaseValid baseValid, string moduleName);
    public Dictionary<string, object> CreateResponseCatch(string moduleName);
}