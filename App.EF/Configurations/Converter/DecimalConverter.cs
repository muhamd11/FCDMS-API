using App.Core.Helper.Validations;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace App.EF.Configurations.Converter
{
    public class DecimalConverter : ValueConverter<decimal, decimal>
    {
        public DecimalConverter() : base(
                de => ConvertToDecimal(de),
                de => ConvertToDecimal(de))
        {
        }

        private static decimal ConvertToDecimal(object value)
        {
            if (value == null)
                value = "";

            return ValidationClass.IsValidNumber(value.ToString()) == false ? 0 : Convert.ToDecimal(string.Format("{0:G29}", value));
        }
    }

    public class DecimalComparer : ValueComparer<decimal>
    {
        public DecimalComparer() : base(
            (d1, d2) => d1 == d2, d => d.GetHashCode())
        {
        }
    }
}