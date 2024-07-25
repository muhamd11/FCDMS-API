using PhoneNumbers;
using System.Text.RegularExpressions;

namespace App.Core.Helper.Validations
{
    public static class ValidationClass
    {
        public static bool IsValidId(int id)
        {
            if (id <= 0)
                return false;
            else
                return true;
        }

        public static bool IsValidString(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return false;
            else
                return true;
        }

        public static bool IsValidStringLength(string str, int length)
        {
            if (str.Length > length)
                return false;
            else
                return true;
        }

        public static bool IsValidHexCode(string code)
        {
            string pattern = @"^#([a-fA-F0-9]{6}|[a-fA-F0-9]{8})$";
            Regex regex = new(pattern);

            if (code.Length > 9)
                return false;

            if (!regex.IsMatch(code))
                return false;
            return true;
        }

        public static bool IsValidEmail(string email)
        {
            var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            Regex regex = new(emailPattern);

            if (!regex.IsMatch(email))
                return false;

            return true;
        }

        public static bool IsValidUrl(string url)
        {
            var urlPattern = @"^(https?:\/\/)?([\da-z\.-]+)\.([a-z\.]{2,6})([/\w \.-]*)*\/?$";
            Regex regex = new(urlPattern);

            if (!regex.IsMatch(url))
                return false;

            return true;
        }

        public static bool IsValidPhoneNumber(string countryCode, string dialingCode, string phoneNumber)
        {
            var phoneNumberUtil = PhoneNumberUtil.GetInstance();
            try
            {
                var numberProto = phoneNumberUtil.Parse(phoneNumber, countryCode);
                var expectedDialingCode = "+" + dialingCode;
                var actualDialingCode = phoneNumberUtil.Format(numberProto, PhoneNumberFormat.INTERNATIONAL).Split(' ')[0];

                if (expectedDialingCode != actualDialingCode)
                    return false;

                return phoneNumberUtil.IsValidNumber(numberProto);
            }
            catch (NumberParseException)
            {
                return false;
            }
        }

        public static bool IsEnumValue<TEnum>(TEnum value) where TEnum : Enum
        {
            return Enum.IsDefined(typeof(TEnum), value);
        }
    }
}