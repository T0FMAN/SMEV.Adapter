using Newtonsoft.Json;
using SMEV.Adapter.Models.MessageContent;
using SMEV.Adapter.Models.Send.Request;

namespace SMEV.Adapter.Models.Send.Response
{
    /// <summary>
    /// Модель отправляемого сообщения-ответа
    /// </summary>
    public sealed class SendResponseModel
    {
        /// <summary>
        /// Инициализация отправляемого сообщения с мнемоникой ИС, 
        /// отличной от стандартной, указанной при инициализации <see cref="MessageExchange"/>
        /// </summary>
        /// <param name="mnemonicIS">Мнемоника ИС, от лица которой будет отправлено сообщение</param>
        /// <param name="message">Сообщение-ответ</param>
        private SendResponseModel(string mnemonicIS, ResponseMessage message) 
        {
            MnemonicIS = mnemonicIS;
            Message = message;
        }

        /// <summary>
        /// Инициализация отправляемого сообщения
        /// </summary>
        /// <param name="message">Сообщение-ответ</param>
        private SendResponseModel(ResponseMessage message) 
        {
            Message = message;
        }

        /// <summary>
        /// Инициализация отправляемого сообщения
        /// </summary>
        /// <param name="clientId">Уникальный идентификатор</param>
        /// <param name="message">Данные сообщения</param>
        /// <param name="testMessage">Тестовое сообщение</param>
        public SendResponseModel(string clientId, string message, bool testMessage = false) :
            this(new ResponseMessage(
                new ResponseMetadata(clientId, clientId, testMessage),
                new ContentModel(new Content(
                    new MessagePrimaryContent(message)))))
        { }

        /// <summary>
        /// Инициализация отправляемого сообщения с мнемоникой ИС, 
        /// отличной от стандартной, указанной при инициализации <see cref="MessageExchange"/>
        /// </summary>
        /// <param name="mnemonicIS">Мнемоника ИС, от лица которой будет отправлено сообщение</param>
        /// <param name="clientId">Уникальный идентификатор</param>
        /// <param name="message">Данные сообщения</param>
        /// <param name="testMessage">Тестовое сообщение</param>
        public SendResponseModel(string mnemonicIS, string clientId, string message, bool testMessage = false) :
            this(mnemonicIS, new ResponseMessage(
                new ResponseMetadata(clientId, clientId, testMessage),
                new ContentModel(new Content(
                    new MessagePrimaryContent(message)))))
        { }

        /// <summary>
        /// Мнемоника ИС
        /// </summary>
        [JsonProperty("itSystem")]
        public string MnemonicIS { get; set; } = default!;
        /// <summary>
        /// Сообщение-запрос
        /// </summary>
        [JsonProperty("responseMessage")]
        public ResponseMessage Message { get; private set; } = default!;
    }
}
