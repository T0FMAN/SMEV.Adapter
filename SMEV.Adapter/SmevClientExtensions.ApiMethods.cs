using SMEV.Adapter.Extensions;
using SMEV.Adapter.Requests.AvailableMethods;
using SMEV.Adapter.Types.Enums;
using SMEV.Adapter.Types.FindMethod;
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
        /// Отправка сообщения с запросом методом <c>Send</c>
        /// </summary>
        /// <returns></returns>
        public static async Task<ResponseSentMessage> SendRequestMessageAsync(
            this ISmevClient client,
            string clientId,
            string messageContent,
            AttachmentHeaderList? attachmentHeaderList = null,
            bool testMessage = false,
            string? mnemonicIS = default,
            CancellationToken cancellationToken = default) =>
            await client.ThrowIfNull()
            .MakeRequestAsync(
                new SendRequestMessageRequest(
                    clientId,
                    messageContent,
                    attachmentHeaderList,
                    testMessage,
                    mnemonicIS),
                cancellationToken)
            .ConfigureAwait(false);

        /// <summary>
        /// Отправка сообщения с ответом методом <c>Send</c>
        /// </summary>
        /// <returns></returns>
        public static async Task<ResponseSentMessage> SendResponseMessageAsync(
            this ISmevClient client,
            string clientId,
            string replyToClientId,
            string messageContent,
            AttachmentHeaderList? attachmentHeaderList = null,
            bool testMessage = false,
            string? mnemonicIS = default,
            CancellationToken cancellationToken = default) =>
            await client.ThrowIfNull()
            .MakeRequestAsync(
                new SendResponseMessageRequest(
                    clientId,
                    replyToClientId,
                    messageContent,
                    attachmentHeaderList,
                    testMessage,
                    mnemonicIS),
                cancellationToken)
            .ConfigureAwait(false);

        /// <summary>
        /// Поиск сообщений по идентификатору сообщения
        /// </summary>
        /// <param name="client"></param>
        /// <param name="mnemonicIS"></param>
        /// <param name="clientId"></param>
        /// <param name="requestType"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<QueryResult> FindMessagesByClientIdAsync(
            this ISmevClient client,
            string clientId,
            ClientCriteriaRequestType requestType,
            string? mnemonicIS = default,
            CancellationToken cancellationToken = default) =>
            await client.ThrowIfNull()
            .MakeRequestAsync(
                new FindMessagesRequest(
                    clientId,
                    requestType,
                    mnemonicIS),
                cancellationToken)
            .ConfigureAwait(false);

        /// <summary>
        /// Поиск сообщений по временному диапазону
        /// </summary>
        /// <param name="client"></param>
        /// <param name="mnemonicIS"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <param name="countToReturn"></param>
        /// <param name="offset"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<QueryResult> FindMessagesByTimeRangeAsync(
            this ISmevClient client,
            DateTime fromDate,
            DateTime toDate,
            int? countToReturn = null,
            int? offset = null,
            string? mnemonicIS = default,
            CancellationToken cancellationToken = default) =>
            await client.ThrowIfNull()
            .MakeRequestAsync(
                new FindMessagesRequest(
                    fromDate,
                    toDate,
                    countToReturn,
                    offset,
                    mnemonicIS),
                cancellationToken)
            .ConfigureAwait(false);

        /// <summary>
        /// Получение сообщения из очереди сообщений
        /// </summary>
        /// <param name="client"></param>
        /// <param name="mnemonicIS"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<FoundMessage> GetMessageFromQueue(
            this ISmevClient client,
            string? mnemonicIS = default,
            CancellationToken cancellationToken = default) =>
            await client.ThrowIfNull()
            .MakeRequestAsync(
                new GetMessageQueueRequest(mnemonicIS),
                cancellationToken)
            .ConfigureAwait(false);
    }
}
