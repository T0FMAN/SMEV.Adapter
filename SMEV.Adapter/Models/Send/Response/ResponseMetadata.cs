using Newtonsoft.Json;

namespace SMEV.Adapter.Models.Send.Response
{
    /// <summary>
    /// Репрезентация метаданных сообщения-ответа
    /// </summary>
    public sealed class ResponseMetadata
    {
        /// <summary>
        /// Инициализация метаданных сообщения-ответа
        /// </summary>
        /// <param name="clientId">Уникальный идентификатор</param>
        /// <param name="replyToClientId">Уникальный идентификатор сообщения, на который ссылается сообщение</param>
        public ResponseMetadata(string clientId, string replyToClientId)
        {
            ClientId = clientId;
            ReplyToClientId = replyToClientId;
        }

        /// <summary>
        /// Уникальный идентифкатор
        /// </summary>
        [JsonProperty("clientId")]
        public string ClientId { get; set; }
        /// <summary>
        /// Уникальный идентификатор сообщения, на который ссылается сообщение
        /// </summary>
        [JsonProperty("replyToClientId")]
        public string ReplyToClientId { get; set; }
    }
}
