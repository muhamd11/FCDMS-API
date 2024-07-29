using App.Core.Consts.GeneralModels;
using App.Core.Models.General.LocalModels;
using App.Core.Models.UsersModule._01._2_UserAuthentications.LoginModule.ViewModel;
using App.Core.Resources.General;
using App.Core.Resources.UsersModules.User;

public class BaseGetDetailsResponse<T> : Dictionary<string, object>
{
    public EnumStatus status { get; set; }
    public string msg { get; set; }
    public decimal executionTimeMilliseconds { get; set; }
    public T Data { get; set; }

    public BaseGetDetailsResponse<T> CreateResponse(T element, string moduleName)
    {
        BaseGetDetailsResponse<T> response = null;
        //when no data found
        if (element is null)
            response = new BaseGetDetailsResponse<T> { msg = GeneralMessagesAr.errorNoData, status = EnumStatus.noContent };
        else
        {
            if (typeof(T) == typeof(UserLoginInfo))
                response = new BaseGetDetailsResponse<T> { msg = UsersMessagesAr.loginSuccess, status = EnumStatus.success, Data = element };
            else
                response = new BaseGetDetailsResponse<T> { msg = GeneralMessagesAr.operationSuccess, status = EnumStatus.success, Data = element };
        }
        //when data found

        response[nameof(status)] = response.status;
        response[nameof(msg)] = response.msg;
        response[nameof(executionTimeMilliseconds)] = response.executionTimeMilliseconds;
        // Add the data with the module name as the key
        response[moduleName] = element;

        return response;
    }

    public BaseGetDetailsResponse<T> CreateResponse(BaseValid baseValid, string moduleName)
    {
        var response = new BaseGetDetailsResponse<T>
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

    public BaseGetDetailsResponse<T> CreateResponseCatch(string moduleName)
    {
        var response = new BaseGetDetailsResponse<T>
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