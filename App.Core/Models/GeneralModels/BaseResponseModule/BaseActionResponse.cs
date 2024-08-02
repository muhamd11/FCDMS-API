using App.Core.Consts.GeneralModels;
using App.Core.Models.General.LocalModels;
using App.Core.Resources.General;

public class BaseActionResponse<T> : Dictionary<string, object>
{
    public EnumStatus status { get; set; }
    public string msg { get; set; }
    public decimal executionTimeMilliseconds { get; set; }
    public T Data { get; set; }

    public BaseActionResponse<T> CreateResponse(BaseActionDone<T> inputModel, string moduleName)
    {
        BaseActionResponse<T> response = null;
        //when no data found
        if (inputModel.Data is null)
            response = new BaseActionResponse<T> { msg = inputModel.Message, status = inputModel.Status };
        else //when data found
            response = new BaseActionResponse<T> { msg = inputModel.Message, status = inputModel.Status, Data = inputModel.Data };

        response[nameof(status)] = response.status;
        response[nameof(msg)] = response.msg;
        response[nameof(executionTimeMilliseconds)] = response.executionTimeMilliseconds;
        // Add the data with the module name as the key
        response[moduleName] = inputModel.Data;

        return response;
    }

    public BaseActionResponse<T> CreateResponse(BaseValid baseValid, string moduleName)
    {
        var response = new BaseActionResponse<T>
        {
            msg = baseValid.Message,
            status = baseValid.Status,
        };
        response[nameof(status)] = response.status;
        response[nameof(msg)] = response.msg;
        response[nameof(executionTimeMilliseconds)] = response.executionTimeMilliseconds;

        // Add the data with the module name as the key
        response[moduleName] = null;

        return response;
    }

    public BaseActionResponse<T> CreateResponseCatch(string moduleName)
    {
        var response = new BaseActionResponse<T>
        {
            msg = GeneralMessagesAr.errorSomthingWrong,
            status = EnumStatus.catchStatus,
        };
        response[nameof(status)] = response.status;
        response[nameof(msg)] = response.msg;
        response[nameof(executionTimeMilliseconds)] = response.executionTimeMilliseconds;
        // Add the data with the module name as the key
        response[moduleName] = null;

        return response;
    }
}