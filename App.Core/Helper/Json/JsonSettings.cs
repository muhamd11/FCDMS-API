using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.Reflection;

namespace App.Core.Helper.Json
{
    public static class JsonSettings
    {
        public static JsonSerializerSettings IgnoreSelfReferencesAndSpecificProperties = new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            ContractResolver = new IgnorePropertiesResolver(new[] { "CodeBase" })
        };
    }

    public class IgnorePropertiesResolver : DefaultContractResolver
    {
        private readonly HashSet<string> _propsToIgnore;

        public IgnorePropertiesResolver(IEnumerable<string> propNamesToIgnore)
        {
            _propsToIgnore = new HashSet<string>(propNamesToIgnore);
        }

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);

            if (_propsToIgnore.Contains(property.PropertyName))
            {
                property.ShouldSerialize = _ => false;
            }

            return property;
        }
    }
}