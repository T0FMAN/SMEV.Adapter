using SMEV.Adapter.Enums;
using System.Net.Http.Headers;

namespace SMEV.Adapter.Http
{
    internal static class HttpExtensions
    {
        internal static async Task<string> EtalonRequest(this HttpClient httpClient, Uri uri, HttpMethod method, string data, MediaType mediaType = MediaType.ApplicationJson)
        {
            if (data is null) { throw new Exception("Data is null!"); }

            var content = new StringContent(data);

            var response = await httpClient.GetResponse(uri, method, content, mediaType);

            return response;
        }

        private static async Task<string> GetResponse(this HttpClient client, 
                                                            Uri uri, 
                                                            HttpMethod method, 
                                                            HttpContent content, 
                                                            MediaType mediaType)
        {
            using (var request = new HttpRequestMessage(method, uri))
            {
                if (content is not null) 
                {
                    request.Content = content;

                    MediaTypeDictionary.TryGetValue(mediaType, out string value);

                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse(value);
                }

                var response = await client.SendAsync(request);

                var data = await response.ReadHttpResponseMessage();

                return data;
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
