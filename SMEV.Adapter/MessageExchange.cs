using SMEV.Adapter.Http;

namespace SMEV.Adapter
{
    public class MessageExchange : IMessageExchange
    {
        private readonly HttpClient _httpClient;
        private readonly HttpMethod _method = HttpMethod.Post;
        
        public MessageExchange() => _httpClient = new HttpClient();

        public void Dispose() => _httpClient.Dispose();

        public async Task<string> Find(string address, string data)
        {
            var uri = new Uri(@$"{address}/find");

            return await _httpClient.GetResponse(uri, _method, data);
        }

        public async Task<string> Get(string address, string data)
        {
            var uri = new Uri(@$"{address}/get");

            return await _httpClient.GetResponse(uri, _method, data);
        }

        public async Task<string> Send(string address, string data)
        {
            var uri = new Uri(@$"{address}/send");

            return await _httpClient.GetResponse(uri, _method, data);
        }
    }
}
