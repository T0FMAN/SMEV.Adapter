using Newtonsoft.Json;
using System.Xml;

namespace SMEV.Adapter.Types.MessageContent
{
    /// <summary>
    /// Контейнер с данными для сообщения запроса
    /// </summary>
    public class MessagePrimaryContent
    {
        [JsonProperty("any")]
        private string _message = default!;

        [JsonConstructor]
        private MessagePrimaryContent([JsonProperty("any")] string message)
        {
            var messageDocument = new XmlDocument();
            messageDocument.LoadXml(message);

            MessageDocument = messageDocument;
        }

        /// <summary>
        /// Инициализация контейнера сообщения запроса
        /// </summary>
        /// <param name="messageDocument">Бизнес-данные запроса, сформированные по XSD-схеме ВС в формате XML</param>
        public MessagePrimaryContent(XmlDocument messageDocument)
        {
            _message = messageDocument.OuterXml;
        }

        /// <summary>
        /// Бизнес-данные запроса, сформированные по XSD-схеме ВС в формате XML
        /// </summary>
        [JsonIgnore]
        public XmlDocument MessageDocument 
        {
            get
            {
                var xDoc = new XmlDocument();
                xDoc.LoadXml(_message);

                return xDoc;
            }
            private set { }
        }
    }
}
