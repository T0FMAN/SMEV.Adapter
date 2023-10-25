using Newtonsoft.Json;

namespace SMEV.Adapter.Models.Send.Request
{
    /// <summary>
    /// Репрезентация метаданных сообщения-запроса
    /// </summary>
    public sealed class RequestMetadata
    {
        /// <summary>
        /// Инициализация метаданных сообщения-запроса
        /// </summary>
        /// <param name="clientId">Уникальный идентификатор</param>
        /// <param name="testMessage">Тестовое сообщение</param>
        public RequestMetadata(string clientId, bool? testMessage = false)
        {
            ClientId = clientId;
            TestMessage = testMessage;
        }

        /// <summary>
        /// Уникальный идентификатор
        /// </summary>
        [JsonProperty("clientId")]
        public string ClientId { get; set; }
        /// <summary>
        /// Тестовое сообщение
        /// </summary>
        [JsonProperty("testMessage")]
        public bool? TestMessage { get; set; }
    }
}
