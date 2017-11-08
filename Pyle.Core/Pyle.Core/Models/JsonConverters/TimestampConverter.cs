using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Pyle.Core.JsonConverters
{
    public class TimestampConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTime);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null || reader.Value is DateTime)
                return new DateTime();

            var t = long.Parse(reader.Value.ToString());
            return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(t).ToLocalTime();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            try
            {
                var dt = (DateTime)value;
                var dtf = new DateTimeOffset(dt);
                var utc = dtf.ToUnixTimeSeconds();
                var t = JToken.FromObject(utc);
                t.WriteTo(writer);
            }

            catch
            {
                var t = JToken.FromObject(new DateTime());
                t.WriteTo(writer);
            }
        }
    }
}
