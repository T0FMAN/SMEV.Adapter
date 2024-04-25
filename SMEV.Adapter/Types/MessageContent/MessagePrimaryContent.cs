using Newtonsoft.Json;

namespace SMEV.Adapter.Types.MessageContent
{
    /// <summary>
    /// Контейнер с данными для сообщения запроса
    /// </summary>
    public sealed class MessagePrimaryContent
    {
        /// <summary>
        /// Инициализация контейнера сообщения запроса
        /// </summary>
        /// <param name="message">Бизнес-данные запроса, сформированные по XSD-схеме ВС в формате XML</param>
        public MessagePrimaryContent(string message)
        {
            AnyMessage = message;
        }

        /// <summary>
        /// Бизнес-данные запроса, сформированные по XSD-схеме ВС в формате XML
        /// </summary>
        [JsonProperty("any")]
        public string AnyMessage { get; set; }
    }
}
