using App.Core.Models.UsersModule._01._2_UserAuthentications.LoginModule;
using Newtonsoft.Json;

namespace App.Core.Helper.Json
{
    public static class JsonConversion
    {
        public static UserAuthorize DeserializeUserAuthorizeToken(string userAuthorizeToken)
        {
            UserAuthorize userAuthorize = null;
            try
            {
                var userAuthorizeJsonString = MethodsClass.Decrypt_Base64(userAuthorizeToken);
                userAuthorize = ConvertJsonToClass<UserAuthorize>(userAuthorizeJsonString) ?? new UserAuthorize();
            }
            catch
            {
                userAuthorize = new UserAuthorize();
            }

            return userAuthorize;
        }

        public static string SerializeUserAuthorizeToken(UserAuthorize userAuthorize)
        {
            string result = ConvertClassToJson(userAuthorize);
            result = MethodsClass.Encrypt_Base64(result);
            return result;
        }

        public static T ConvertJsonToClass<T>(string json) => JsonConvert.DeserializeObject<T>(json);

        public static string ConvertClassToJson<T>(T c)
        {
            if (c == null)
                return string.Empty;
            else
                return JsonConvert.SerializeObject(c);
        }
    }
}