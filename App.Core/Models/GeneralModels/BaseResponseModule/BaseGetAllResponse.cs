using App.Core.Consts.GeneralModels;
using App.Core.Models.General;
using App.Core.Models.General.LocalModels;
using App.Core.Resources.General;

public class BaseGetAllResponse<T> : Dictionary<string, object>
{
    public EnumStatus status { get; set; }
    public string msg { get; set; }
    public decimal executionTimeMilliseconds { get; set; } = 0;
    public Pagination pagination { get; set; }
    public IEnumerable<T> Data { get; set; }

    public BaseGetAllResponse<T> CreateResponseSuccessOrNoContent(BaseGetDataWithPagnation<T> inputModel, string moduleName)
    {
        BaseGetAllResponse<T> response = null;
        //when no data found
        if (!inputModel.Data.Any())
            response = new BaseGetAllResponse<T> { msg = GeneralMessagesAr.errorDataNotFound, status = EnumStatus.noContent };
        else //when data found
            response = new BaseGetAllResponse<T>
            {
                msg = GeneralMessagesAr.operationSuccess,
                status = EnumStatus.success,
                pagination = inputModel.Pagination,
                Data = inputModel.Data
            };

        response[nameof(status)] = response.status;
        response[nameof(msg)] = response.msg;
        response[nameof(executionTimeMilliseconds)] = response.executionTimeMilliseconds;
        response["pagination"] = response.pagination;
        // Add the data with the module name as the key
        response[moduleName] = inputModel.Data;

        return response;
    }

    public BaseGetAllResponse<T> CreateResponseError(BaseValid baseValid, string moduleName)
    {
        var response = new BaseGetAllResponse<T>
        {
            msg = baseValid.Message,
            status = baseValid.Status,
        };
        response[nameof(status)] = response.status;
        response[nameof(msg)] = response.msg;
        response[nameof(executionTimeMilliseconds)] = response.executionTimeMilliseconds;
        response["pagination"] = response.pagination;
        // Add the data with the module name as the key
        response[moduleName] = null;

        return response;
    }

    public BaseGetAllResponse<T> CreateResponseCatch(string moduleName)
    {
        var response = new BaseGetAllResponse<T>
        {
            msg = GeneralMessagesAr.errorSomthingWrong,
            status = EnumStatus.catchStatus,
        };
        response[nameof(status)] = response.status;
        response[nameof(msg)] = response.msg;
        response[nameof(executionTimeMilliseconds)] = response.executionTimeMilliseconds;
        response["pagination"] = response.pagination;
        // Add the data with the module name as the key
        response[moduleName] = null;

        return response;
    }
}