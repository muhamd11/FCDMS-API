using App.Core.Consts.GeneralModels;
using App.Core.Models.General.LocalModels;
using App.Core.Resources.General;

public class BaseActionResponse: IBaseActionResponse
{
    public Dictionary<string, object> CreateResponse<T>(BaseActionDone<T> inputData, string moduleName)
    {

        Dictionary<string, object> response = new();
        //when no data found
        if (inputData.Data is null)
        {
            response.Add("msg", inputData.Message);
            response.Add("status", inputData.Status);
            response.Add("executionTimeMilliseconds", 0);
            response.Add(moduleName, null);
        }
        else //when data found
        {
            response.Add("msg", inputData.Message);
            response.Add("status", inputData.Status);
            response.Add("executionTimeMilliseconds", 0);
            response.Add(moduleName, inputData.Data);
        }

        return response;
    }

    public Dictionary<string, object> CreateResponse(BaseValid baseValid, string moduleName)
    {
        Dictionary<string, object> response = new(){
            { "msg", baseValid.Message },
            { "status", baseValid.Status },
            { "executionTimeMilliseconds", 0 },
            { moduleName, null }
            };

        return response;
    }

    public Dictionary<string, object> CreateResponseCatch(string moduleName)
    {
        Dictionary<string, object> response = new(){
            { "msg", GeneralMessagesAr.errorSomthingWrong },
            { "status", EnumStatus.catchStatus },
            { "executionTimeMilliseconds", 0 },
             { moduleName, null }
        };

        return response;
    }
}

