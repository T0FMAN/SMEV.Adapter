using SMEV.Adapter.Http;

namespace SMEV.Adapter
{
    public class MessageExchange : IMessageExchange
    {
        private readonly HttpClient _httpClient;
        private readonly HttpMethod _method;
        /// <summary>
        /// Создание экземпляра реализации интерфейса, принимающий базовый адрес веб-сервиса
        /// </summary>
        /// <param name="baseAddress">Адрес веб-сервиса REST-API (включая его контекстный путь). Например, http://localhost:8085/ws</param>
        public MessageExchange()
        {
            _httpClient = new HttpClient();
            _method = HttpMethod.Post;
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }

        public async Task<string> Find(string address, string data)
        {
            var uri = new Uri(@$"{address}/find");

            return await _httpClient.EtalonRequest(uri, _method, data);
        }

        public async Task<string> Get(string address, string data)
        {
            var uri = new Uri(@$"{address}/get");

            return await _httpClient.EtalonRequest(uri, _method, data);
        }

        public async Task<string> Send(string address, string data)
        {
            var uri = new Uri(@$"{address}/send");

            return await _httpClient.EtalonRequest(uri, _method, data);
        }
    }
}
