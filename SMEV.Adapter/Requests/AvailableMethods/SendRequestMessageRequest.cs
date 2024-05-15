using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SMEV.Adapter.Types;
using SMEV.Adapter.Types.MessageContent;
using SMEV.Adapter.Types.MessageMetadata;
using System.Diagnostics.CodeAnalysis;

namespace SMEV.Adapter.Requests.AvailableMethods
{
    /// <summary>
    /// Используйте этот метод для отправки сообщения с запросом к СМЭВ. В случае успеха возвращается <see cref="MessageResult"/>
    /// </summary>
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class SendRequestMessageRequest : RequestBase<MessageResult>
    {
        /// <summary>
        /// Наименование очереди для отправки ответа
        /// </summary>
        [JsonProperty("replyToQueue", NullValueHandling = NullValueHandling.Ignore)]
        public string? Queue { get; init; } = default!;

        /// <summary>
        /// Отправляемый запрос
        /// </summary>
        [JsonProperty("requestMessage")]
        public RequestMessage RequestMessage { get; init; } = default!;

        /// <summary>
        /// Инициализация нового запроса с метаданными и контентом
        /// </summary>
        [SetsRequiredMembers]
        public SendRequestMessageRequest(
            string clientId,
            string messageContent,
            string? originalContent = default,
            AttachmentHeaderList? attachmentHeaderList = default,
            bool testMessage = default,
            string? queue = default,
            string? mnemonicIS = default)
            : this(mnemonicIS)
        {
            Queue = queue;
            RequestMessage = new RequestMessage(
                metadata: new RequestMetadata()
                {
                    ClientId = clientId,
                    TestMessage = testMessage,
                },
                content: new RequestContent()
                {
                    OriginalContent = originalContent,
                    Content = new Content(
                        new MessagePrimaryContent(messageContent),
                        attachmentHeaderList)
                });
        }

        /// <summary>
        /// Инициализация нового запроса
        /// </summary>
        private SendRequestMessageRequest(string? mnemonicIS = default)
            : base("send", mnemonicIS)
        { }
    }
}
