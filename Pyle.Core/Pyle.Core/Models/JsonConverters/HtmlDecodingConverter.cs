using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Pyle.Core.JsonConverters
{
    public class HtmlDecodingConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (string.IsNullOrEmpty(reader.Value as string))
                return string.Empty;

            var t = reader.Value as string;
            return System.Net.WebUtility.HtmlDecode(t);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var t = JToken.FromObject(value);
            t.WriteTo(writer);
        }
    }
}
