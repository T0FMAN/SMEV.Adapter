using SMEV.Adapter.Enums;
using System.Net.Http.Headers;

namespace SMEV.Adapter.Http
{
    internal static class HttpExtensions
    {
        internal static async Task<string> GetResponse(this HttpClient client, Uri uri, HttpMethod method, string data, MediaType mediaType = MediaType.ApplicationJson)
        {
            if (data is null) 
                throw new Exception("Data is null");

            if (!MediaTypeDictionary.TryGetValue(mediaType, out string value)) 
                throw new Exception("Invalid media type");

            using (var request = new HttpRequestMessage(method, uri))
            {
                var content = new StringContent(data);

                request.Content = content;
                request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse(value);

                var response = await client.SendAsync(request);

                var responseData = await response.ReadHttpResponseMessage();

                return responseData;
            };
        }

        private static async Task<string> ReadHttpResponseMessage(this HttpResponseMessage response)
        {
            var data = await response.Content.ReadAsStringAsync();

            return data;
        }

        internal readonly static Dictionary<MediaType, string> MediaTypeDictionary = new()
        {
            { MediaType.ApplicationJson, "application/json" },
        };
    }
}
