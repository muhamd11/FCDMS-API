using App.Core.Consts.GeneralModels;
using App.Core.Models.General;
using App.Core.Models.General.LocalModels;
using App.Core.Resources.General;
using System.Collections.Generic;
using System.Linq;

public class BaseGetAllResponse<T> : Dictionary<string, object>
{
    public EnumStatus Status { get; set; }
    public string Message { get; set; }
    public decimal ExecutionTimeMilliseconds { get; set; } = 0;
    public Pagination Pagination { get; set; }
    public IEnumerable<T> Data { get; set; }

    public BaseGetAllResponse<T> CreateResponseSuccessOrNoContent(BaseGetDataWithPagnation<T> inputModel, string moduleName)
    {
        BaseGetAllResponse<T> response = null;
        //when no data found
        if (!inputModel.Data.Any())
            response = new BaseGetAllResponse<T> { Message = GeneralMessages.errorDataNotFound, Status = EnumStatus.noContent };
        else //when data found
            response = new BaseGetAllResponse<T>
            {
                Message = GeneralMessages.operationSuccess,
                Status = EnumStatus.success,
                Pagination = inputModel.Pagination,
                Data = inputModel.Data
            };

        response[nameof(Status)] = response.Status;
        response[nameof(Message)] = response.Message;
        response[nameof(ExecutionTimeMilliseconds)] = response.ExecutionTimeMilliseconds;
        response[nameof(Pagination)] = response.Pagination;
        // Add the data with the module name as the key
        response[moduleName] = inputModel.Data;

        return response;
    }

    public BaseGetAllResponse<T> CreateResponseError(BaseValid baseValid, string moduleName)
    {
        var response = new BaseGetAllResponse<T>
        {
            Message = baseValid.Message,
            Status = baseValid.Status,
        };
        response[nameof(Status)] = response.Status;
        response[nameof(Message)] = response.Message;
        response[nameof(ExecutionTimeMilliseconds)] = response.ExecutionTimeMilliseconds;
        response[nameof(Pagination)] = response.Pagination;
        // Add the data with the module name as the key
        response[moduleName] = null;

        return response;
    }

    public BaseGetAllResponse<T> CreateResponseCatch(string moduleName)
    {
        var response = new BaseGetAllResponse<T>
        {
            Message = GeneralMessages.errorSomthingWrong,
            Status = EnumStatus.catchStatus,
        };
        response[nameof(Status)] = response.Status;
        response[nameof(Message)] = response.Message;
        response[nameof(ExecutionTimeMilliseconds)] = response.ExecutionTimeMilliseconds;
        response[nameof(Pagination)] = response.Pagination;
        // Add the data with the module name as the key
        response[moduleName] = null;

        return response;
    }
}