using SMEV.Adapter.Http;

namespace SMEV.Adapter
{
    public class MessageExchange : IMessageExchange
    {
        private readonly HttpClient _httpClient;
        private readonly string Address;
        /// <summary>
        /// Конструктор для инициализации параметров
        /// </summary>
        /// <param name="address">Адрес веб-сервиса адапатера, включая его контекстный путь, например, 'http://localhost:7590/ws'</param>
        public MessageExchange(string address)
        {
            _httpClient = new HttpClient();
            Address = address;
        }

        public void Dispose() => _httpClient.Dispose();
        
        public async Task<string> Find(string data)
        {
            var uri = new Uri(@$"{Address}/find");

            return await _httpClient.GetResponse(uri, data);
        }

        public async Task<string> Get(string data)
        {
            var uri = new Uri(@$"{Address}/get");

            return await _httpClient.GetResponse(uri, data);
        }

        public async Task<string> Send(string data)
        {
            var uri = new Uri(@$"{Address}/send");

            return await _httpClient.GetResponse(uri, data);
        }
    }
}
