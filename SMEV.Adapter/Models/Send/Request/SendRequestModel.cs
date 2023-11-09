using Newtonsoft.Json;
using SMEV.Adapter.Models.MessageContent;

namespace SMEV.Adapter.Models.Send.Request
{
    /// <summary>
    /// Модель отправляемого сообщения-запроса
    /// </summary>
    public sealed class SendRequestModel
    {
        /// <summary>
        /// Инициализация отправляемого сообщения с мнемоникой ИС, 
        /// отличной от стандартной, указанной при инициализации <see cref="MessageExchange"/>
        /// </summary>
        /// <param name="mnemonicIS">Мнемоника ИС, от лица которой будет отправлено сообщение</param>
        /// <param name="message">Сообщение-запрос</param>
        private SendRequestModel(string mnemonicIS, RequestMessage message)
        {
            MnemonicIS = mnemonicIS;
            Message = message;
        }

        /// <summary>
        /// Инициализация отправляемого сообщения
        /// </summary>
        /// <param name="message">Сообщение-запрос</param>
        private SendRequestModel(RequestMessage message)
        {
            Message = message;
        }

        /// <summary>
        /// Инициализация отправляемого сообщения
        /// </summary>
        /// <param name="clientId">Уникальный идентификатор</param>
        /// <param name="message">Данные сообщения</param>
        /// <param name="testMessage">Тестовое сообщение</param>
        public SendRequestModel(string clientId, string message, bool testMessage = false) : 
            this(new RequestMessage(
                new RequestMetadata(clientId, testMessage), 
                new ContentModel(new Content(
                    new MessagePrimaryContent(message)))))
        { }

        /// <summary>
        /// Инициализация отправляемого сообщения
        /// </summary>
        /// <param name="mnemonicIS">Мнемоника ИС, от лица которой будет отправлено сообщение</param>
        /// <param name="clientId">Уникальный идентификатор</param>
        /// <param name="message">Данные сообщения</param>
        /// <param name="testMessage">Тестовое сообщение</param>
        public SendRequestModel(string mnemonicIS, string clientId, string message, bool testMessage = false) :
            this(mnemonicIS, new RequestMessage(
                new RequestMetadata(clientId, testMessage),
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
        [JsonProperty("requestMessage")]
        public RequestMessage Message { get; private set; } = default!;
    }
}
