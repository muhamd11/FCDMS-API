using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Reflection;

namespace API
{
    public class NullToEmptyStringResolver : CamelCasePropertyNamesContractResolver
    {
        /// <summary>
        ///  Create properties
        /// </summary>
        /// <param name="type"> type </param>
        /// <param name="memberSerialization"> Serialize members </param>
        /// <returns></returns>
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            return type.GetProperties().Select(c =>
            {
                var jsonProperty = base.CreateProperty(c, memberSerialization);
                jsonProperty.ValueProvider = new NullToEmptyStringValueProvider(c);
                return jsonProperty;
            }).ToList();
        }
    }

    public class NullToEmptyStringValueProvider : IValueProvider
    {
        private readonly PropertyInfo _memberInfo;

        /// <summary>
        ///  Constructors
        /// </summary>
        /// <param name="memberInfo"></param>
        public NullToEmptyStringValueProvider(PropertyInfo memberInfo)
        {
            _memberInfo = memberInfo;
        }

        /// <summary>
        ///  obtain Value
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public object GetValue(object target)
        {
            var result = _memberInfo.GetValue(target);
            if (_memberInfo.PropertyType == typeof(string) && result == null)
                result = string.Empty;
            return result;
        }

        public void SetValue(object target, object value)
        {
            _memberInfo.SetValue(target, value);
        }
    }
}