using SMEV.Adapter.Enums;
using System.Net.Http.Headers;

namespace SMEV.Adapter.Extensions
{
    internal static class HttpExtensions
    {
        internal static async Task<string> GetResponse(this HttpClient client, Uri uri, string data, MediaType mediaType = MediaType.ApplicationJson)
        {
            if (data is null)
                throw new Exception("Data is null");

            if (!MediaTypeDictionary.TryGetValue(mediaType, out var value))
                throw new Exception("Invalid media type");

            var method = HttpMethod.Post;

            using (var request = new HttpRequestMessage(method, uri))
            {
                var content = new StringContent(data);

                request.Content = content;
                request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse(value);

                var response = await client.SendAsync(request);
                var responseData = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                    throw new Exception($"Адаптер не смог обработать сообщение.\n" +
                                        $"Ошибка {response.StatusCode}: {responseData}");

                return responseData;
            };
        }

        internal readonly static Dictionary<MediaType, string> MediaTypeDictionary = new()
        {
            { MediaType.ApplicationJson, "application/json" },
        };
    }
}
