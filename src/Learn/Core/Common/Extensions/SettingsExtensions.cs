using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Plugin.Settings.Abstractions;

namespace Learn.Core.Common.Extensions
{
    public static class SettingsExtensions
    {
        public static T GetValueOrDefault<T>(this ISettings settings, string key, T @default) where T : class
        {
            string serialized = settings.GetValueOrDefault(key, string.Empty);
            T result = @default;

            try
            {
                var serializeSettings = GetSerializerSettings();
                result = JsonConvert.DeserializeObject<T>(serialized);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error deserializing settings value: {ex}");
            }

            return result;
        }


        public static bool AddOrUpdateValue<T>(this ISettings settings, string key, T obj) where T : class
        {
            try
            {
                var serializeSettings = GetSerializerSettings();
                string serialized = JsonConvert.SerializeObject(obj, serializeSettings);
                
                return settings.AddOrUpdateValue(key, serialized);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error serializing settings value: {ex}");
            }

            return false;
        }

        private static JsonSerializerSettings GetSerializerSettings()
        {
            return new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
        }
    }
}
