using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace App.Core.Helper
{
    public static class MethodsClass
    {
        public static string Encrypt_Base64(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

        public static string Decrypt_Base64(string base64Encoded)
        {
            var base64EncodedBytes = Convert.FromBase64String(base64Encoded);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}