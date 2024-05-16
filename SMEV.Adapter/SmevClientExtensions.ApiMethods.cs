using SMEV.Adapter.Extensions;
using SMEV.Adapter.Requests.AvailableMethods;
using SMEV.Adapter.Types;
using SMEV.Adapter.Types.Enums;
using SMEV.Adapter.Types.Find;
using SMEV.Adapter.Types.MessageContent;

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
        /// <returns>Экземпляр <see cref="MessageResult"/></returns>
        public static async Task<MessageResult> SendRequestMessageAsync(
            this ISmevClient client,
            string clientId,
            string messageContent,
            string? originalContent = default,
            AttachmentHeaderList? attachmentHeaderList = default,
            bool testMessage = false,
            string? queue = default,
            string? mnemonicIS = default,
            CancellationToken cancellationToken = default) =>
            await client.ThrowIfNull()
            .MakeRequestAsync(
                new SendRequestMessageRequest(
                    clientId,
                    messageContent,
                    originalContent,
                    attachmentHeaderList,
                    testMessage,
                    queue,
                    mnemonicIS),
                cancellationToken)
            .ConfigureAwait(false);

        /// <summary>
        /// Отправка сообщения с ответом методом <c>Send</c>
        /// </summary>
        /// <returns>Экземпляр <see cref="MessageResult"/></returns>
        public static async Task<MessageResult> SendResponseMessageAsync(
            this ISmevClient client,
            string clientId,
            string replyToClientId,
            string messageContent,
            string? originalContent = default,
            AttachmentHeaderList? attachmentHeaderList = default,
            bool? testMessage = false,
            string? mnemonicIS = default,
            CancellationToken cancellationToken = default) =>
            await client.ThrowIfNull()
            .MakeRequestAsync(
                new SendResponseMessageRequest(
                    clientId,
                    replyToClientId,
                    messageContent,
                    originalContent,
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
        public static async Task<QueryResultList> FindMessagesByClientIdAsync(
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
        public static async Task<QueryResultList> FindMessagesByTimeRangeAsync(
            this ISmevClient client,
            DateTime fromDate,
            DateTime? toDate = default,
            int? countToReturn = default,
            int? offset = default,
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
        /// <param name="nodeId"></param>
        /// <param name="queue"></param>
        /// <param name="findType"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<AdapterMessage> GetMessageFromQueue(
            this ISmevClient client,
            string? mnemonicIS = default,
            string? nodeId = default,
            string? queue = default,
            MessageFindType? findType = default,
            CancellationToken cancellationToken = default) =>
            await client.ThrowIfNull()
            .MakeRequestAsync(
                new GetMessageQueueRequest(
                    mnemonicIS, nodeId, queue, findType),
                cancellationToken)
            .ConfigureAwait(false);
    }
}
