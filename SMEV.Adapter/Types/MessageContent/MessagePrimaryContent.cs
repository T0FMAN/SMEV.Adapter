using Newtonsoft.Json;
using System.Xml;

namespace SMEV.Adapter.Types.MessageContent
{
    /// <summary>
    /// Контейнер с данными для сообщения запроса
    /// </summary>
    public class MessagePrimaryContent
    {
        /// <summary>
        /// Инициализация контейнера сообщения запроса
        /// </summary>
        /// <param name="message">Бизнес-данные запроса, сформированные по XSD-схеме ВС в формате XML</param>
        [JsonConstructor]
        public MessagePrimaryContent([JsonProperty("any")] string message)
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(message);

            XmlDocument = xmlDocument;
        }

        /// <summary>
        /// Бизнес-данные запроса, сформированные по XSD-схеме ВС в формате XML
        /// </summary>
        [JsonIgnore]
        public XmlDocument XmlDocument { get; set; }
    }
}
