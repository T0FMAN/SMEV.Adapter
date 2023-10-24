using Newtonsoft.Json;
using SMEV.Adapter.Enums;
using SMEV.Adapter.Models.Find.FoundRequest;
using SMEV.Adapter.Models.Find.FoundResponse;

namespace SMEV.Adapter.Models.Find
{
    /// <summary>
    /// Репрезентация найденного сообщения
    /// </summary>
    public sealed class FoundMessage
    {
        private object _message = default!;

        private MessageType _messageType;

        [JsonConstructor]
        private FoundMessage(SmevMetadata smevMetadata, object message)
        {
            SmevMetadata = smevMetadata;
            SetMessageData(message);
        }

        private void SetMessageData(object message)
        {
            dynamic messageDynamic = message;

            string messageTypeDynamic = Convert.ToString(messageDynamic.messageType);

            _messageType = Enum.Parse<MessageType>(messageTypeDynamic);

            switch (_messageType)
            {
                case MessageType.ResponseMessageType:
                    {
                        _message = JsonConvert.DeserializeObject<FoundResponseMessage>(message.ToString()!)!;
                        break;
                    }
                case MessageType.RequestMessageType:
                    {
                        _message = JsonConvert.DeserializeObject<FoundRequestMessage>(message.ToString()!)!;
                        break;
                    }
                default: throw new InvalidDataException();
            }
        }

        /// <summary>
        /// Метадата данных СМЭВ
        /// </summary>
        [JsonProperty("smevMetadata")]
        public SmevMetadata SmevMetadata { get; set; }

        /// <summary>
        /// Данные сообщения
        /// </summary>
        [JsonProperty("message")]
        public object Message 
        {
            get 
            {
                return _message;
            }
        }
    }
}
