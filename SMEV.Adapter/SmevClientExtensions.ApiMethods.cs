using SMEV.Adapter.Extensions;
using SMEV.Adapter.Requests.AvailableMethods;
using SMEV.Adapter.Types.MessageContent;
using SMEV.Adapter.Types.SendMethod;

namespace SMEV.Adapter
{
    /// <summary>
    /// Методы расширений, соответствующие запросам из документации API
    /// </summary>
    public static class SmevClientExtensions
    {
        /// <summary>
        /// Отправка запроса методом <c>Send</c>
        /// </summary>
        /// <returns></returns>
        public static async Task<ResponseSentMessage> SendRequestAsync(
            this ISmevClient client,
            string mnemonicIS,
            string clientId,
            string messageContent,
            AttachmentHeaderList? attachmentHeaderList = null,
            bool testMessage = false,
            CancellationToken cancellationToken = default) =>
            await client.ThrowIfNull()
            .MakeRequestAsync(
                new SendRequestMessageRequest(
                    mnemonicIS,
                    clientId,
                    messageContent,
                    attachmentHeaderList,
                    testMessage),
                cancellationToken)
            .ConfigureAwait(false);

        /// <summary>
        /// Отправка ответа методом <c>Send</c>
        /// </summary>
        /// <returns></returns>
        public static async Task<ResponseSentMessage> SendAsync(
            this ISmevClient client,
            string mnemonicIS,
            string clientId,
            string replyToClientId,
            string messageContent,
            AttachmentHeaderList? attachmentHeaderList = null,
            bool testMessage = false,
            CancellationToken cancellationToken = default) =>
            await client.ThrowIfNull()
            .MakeRequestAsync(
                new SendResponseMessageRequest(
                    mnemonicIS,
                    clientId,
                    replyToClientId,
                    messageContent,
                    attachmentHeaderList,
                    testMessage),
                cancellationToken)
            .ConfigureAwait(false);

    }
}
