using App.Core.Consts.GeneralModels;
using App.Core.Models.General.LocalModels;
using App.Core.Resources.General;
using System.Collections.Generic;

public class BaseActionResponse<T> : Dictionary<string, object>
{
    public EnumStatus Status { get; set; }
    public string Message { get; set; }
    public decimal ExecutionTimeMilliseconds { get; set; }
    public T Data { get; set; }

    public BaseActionResponse<T> CreateResponse(BaseActionDone<T> inputModel, string moduleName)
    {
        BaseActionResponse<T> response = null;
        //when no data found
        if (inputModel.Data is null)
            response = new BaseActionResponse<T> { Message = inputModel.Message, Status = inputModel.Status };
        else //when data found
            response = new BaseActionResponse<T> { Message = inputModel.Message, Status = inputModel.Status, Data = inputModel.Data };

        response[nameof(Status)] = response.Status;
        response[nameof(Message)] = response.Message;
        response[nameof(ExecutionTimeMilliseconds)] = response.ExecutionTimeMilliseconds;
        // Add the data with the module name as the key
        response[moduleName] = inputModel.Data;

        return response;
    }

    public BaseActionResponse<T> CreateResponse(BaseValid baseValid, string moduleName)
    {
        var response = new BaseActionResponse<T>
        {
            Message = baseValid.Message,
            Status = baseValid.Status,
        };
        response[nameof(Status)] = response.Status;
        response[nameof(Message)] = response.Message;
        response[nameof(ExecutionTimeMilliseconds)] = response.ExecutionTimeMilliseconds;
        // Add the data with the module name as the key
        response[moduleName] = null;

        return response;
    }

    public BaseActionResponse<T> CreateResponseCatch(string moduleName)
    {
        var response = new BaseActionResponse<T>
        {
            Message = GeneralMessages.errorSomthingWrong,
            Status = EnumStatus.catchStatus,
        };
        response[nameof(Status)] = response.Status;
        response[nameof(Message)] = response.Message;
        response[nameof(ExecutionTimeMilliseconds)] = response.ExecutionTimeMilliseconds;
        // Add the data with the module name as the key
        response[moduleName] = null;

        return response;
    }
}