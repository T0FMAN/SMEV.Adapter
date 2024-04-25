using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SMEV.Adapter.Types.MessageContent;
using SMEV.Adapter.Types.SendMethod;
using SMEV.Adapter.Types.SendMethod.Response;
using System.Diagnostics.CodeAnalysis;

namespace SMEV.Adapter.Requests.AvailableMethods
{
    /// <summary>
    ///  Используйте этот метод для отправки ответа к адаптеру. В случае успеха возвращается <see cref="ResponseSentMessage"/>
    /// </summary>
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class SendResponseMessageRequest : RequestBase<ResponseSentMessage>
    {
        /// <summary>
        /// Мнемоника ИС
        /// </summary>
        [JsonProperty("itSystem")]
        public string MnemonicIS { get; init; }

        /// <summary>
        /// Отправляемый ответ
        /// </summary>
        [JsonProperty("responseMessage")]
        public ResponseMessage ResponseMessage { get; init; }

        /// <summary>
        /// Инициализация нового ответа с метаданными и контентом
        /// </summary>
        [SetsRequiredMembers]
        public SendResponseMessageRequest(
            string mnemonicIS,
            string clientId,
            string replyToClientId,
            string messageContent,
            AttachmentHeaderList? attachmentHeaderList = null,
            bool testMessage = false)
            : this()
        {
            MnemonicIS = mnemonicIS;
            ResponseMessage = new ResponseMessage(
                metadata: new ResponseMetadata(clientId, replyToClientId, testMessage),
                content: new ContentModel(
                    new Content(
                        messagePrimaryContent: new MessagePrimaryContent(messageContent),
                        attachmentHeaderList)));
        }

        /// <summary>
        /// Инициализация нового запроса
        /// </summary>
        public SendResponseMessageRequest()
            : base("send")
        { }
    }
}
