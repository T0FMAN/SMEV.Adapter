using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SMEV.Adapter.Types.MessageContent;
using SMEV.Adapter.Types.SendMethod;
using SMEV.Adapter.Types.SendMethod.Request;
using System.Diagnostics.CodeAnalysis;

namespace SMEV.Adapter.Requests.AvailableMethods
{
    /// <summary>
    /// Используйте этот метод для отправки запроса к адаптеру. В случае успеха возвращается <see cref="ResponseSentMessage"/>
    /// </summary>
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class SendRequestMessageRequest : RequestBase<ResponseSentMessage>
    {
        /// <summary>
        /// Мнемоника ИС
        /// </summary>
        [JsonProperty("itSystem")]
        public string MnemonicIS { get; init; }

        /// <summary>
        /// Отправляемый запрос
        /// </summary>
        [JsonProperty("requestMessage")]
        public RequestMessage RequestMessage { get; init; }

        /// <summary>
        /// Инициализация нового запроса с метаданными и контентом
        /// </summary>
        [SetsRequiredMembers]
        public SendRequestMessageRequest(
            string mnemonicIS,
            string clientId,
            string messageContent,
            AttachmentHeaderList? attachmentHeaderList = null,
            bool testMessage = false)
            : this()
        {
            MnemonicIS = mnemonicIS;
            RequestMessage = new RequestMessage(
                metadata: new RequestMetadata(clientId, testMessage),
                content: new ContentModel(
                    new Content(
                        messagePrimaryContent: new MessagePrimaryContent(messageContent),
                        attachmentHeaderList)));
        }

        /// <summary>
        /// Инициализация нового запроса
        /// </summary>
        public SendRequestMessageRequest()
            : base("send")
        { }
    }
}
