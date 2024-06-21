using Newtonsoft.Json;

namespace Cliente.ConsultaAPI.Client.Helpers
{
    internal static class HttpResponseMessageExtensions
    {
        internal static async Task<T?> ParseStreamAsync<T>(
            this HttpResponseMessage response,
            JsonSerializerSettings? serializerSettings = null)
        {
            using var stream = await response.Content.ReadAsStreamAsync();
            using var streamReader = new StreamReader(stream);
            using JsonReader jsonReader = new JsonTextReader(streamReader);

            var serializer = serializerSettings == null
                ? JsonSerializer.CreateDefault()
                : JsonSerializer.Create(serializerSettings);

            return serializer.Deserialize<T>(jsonReader);
        }
    }
}
