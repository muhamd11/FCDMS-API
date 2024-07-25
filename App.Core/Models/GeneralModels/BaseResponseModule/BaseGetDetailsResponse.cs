using App.Core.Consts.GeneralModels;
using App.Core.Models.General.LocalModels;
using App.Core.Resources.General;
using System.Collections.Generic;

public class BaseGetDetailsResponse<T> : Dictionary<string, object>
{
    public EnumStatus Status { get; set; }
    public string Message { get; set; }
    public decimal ExecutionTimeMilliseconds { get; set; }
    public T Data { get; set; }

    public BaseGetDetailsResponse<T> CreateResponse(T element, string moduleName)
    {
        BaseGetDetailsResponse<T> response = null;
        //when no data found
        if (element is null)
            response = new BaseGetDetailsResponse<T> { Message = GeneralMessages.errorNoData, Status = EnumStatus.noContent };
        else //when data found
            response = new BaseGetDetailsResponse<T> { Message = GeneralMessages.operationSuccess, Status = EnumStatus.success, Data = element };

        response[nameof(Status)] = response.Status;
        response[nameof(Message)] = response.Message;
        response[nameof(ExecutionTimeMilliseconds)] = response.ExecutionTimeMilliseconds;
        // Add the data with the module name as the key
        response[moduleName] = element;

        return response;
    }

    public BaseGetDetailsResponse<T> CreateResponse(BaseValid baseValid, string moduleName)
    {
        var response = new BaseGetDetailsResponse<T>
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

    public BaseGetDetailsResponse<T> CreateResponseCatch(string moduleName)
    {
        var response = new BaseGetDetailsResponse<T>
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