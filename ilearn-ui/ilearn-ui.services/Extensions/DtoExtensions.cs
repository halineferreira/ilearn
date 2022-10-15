using System.Text.Json;
using System.Text.Json.Serialization;

namespace ilearn_ui.services.Extensions
{
    public static class DtoExtensions
    {
        public static string ToSerializedJson<T>(this T dto)
        {
            return JsonSerializer.Serialize(dto);
        }

        public static T Deserialize<T>(this string json)
        {
            return JsonSerializer.Deserialize<T>(json,
              new JsonSerializerOptions
              {
                  PropertyNameCaseInsensitive = true,
                  Converters = { new JsonStringEnumConverter() },
                  ReadCommentHandling = JsonCommentHandling.Skip,
                  AllowTrailingCommas = true
              });
        }
    }
}
