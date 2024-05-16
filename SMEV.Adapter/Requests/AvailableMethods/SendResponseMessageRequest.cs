using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SMEV.Adapter.Types;
using SMEV.Adapter.Types.MessageContent;
using SMEV.Adapter.Types.MessageMetadata;
using System.Diagnostics.CodeAnalysis;

namespace SMEV.Adapter.Requests.AvailableMethods
{
    /// <summary>
    ///  Используйте этот метод для отправки сообщения с ответом к СМЭВ. В случае успеха возвращается <see cref="MessageResult"/>
    /// </summary>
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class SendResponseMessageRequest : RequestBase<MessageResult>
    {
        /// <summary>
        /// Отправляемый ответ
        /// </summary>
        [JsonProperty("responseMessage")]
        public ResponseMessage ResponseMessage { get; init; } = default!;

        /// <summary>
        /// Инициализация нового ответа с метаданными и контентом
        /// </summary>
        [SetsRequiredMembers]
        public SendResponseMessageRequest(
            string clientId,
            string replyToClientId,
            string messageContent,
            string? originalContent = default,
            AttachmentHeaderList? attachmentHeaderList = default,
            bool? testMessage = false,
            string? mnemonicIS = default)
            : this(mnemonicIS)
        {
            ResponseMessage = new ResponseMessage(
                metadata: new ResponseMetadata()
                {
                    ClientId = clientId,
                    ReplyToClientId = replyToClientId,
                    TestMessage = testMessage
                },
                content: new ResponseContent()
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
        private SendResponseMessageRequest(string? mnemonicIS = default)
            : base("send", mnemonicIS)
        { }
    }
}
