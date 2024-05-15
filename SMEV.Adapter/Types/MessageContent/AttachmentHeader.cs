using Newtonsoft.Json;
using SMEV.Adapter.Types.Enums;

namespace SMEV.Adapter.Types.MessageContent
{
    /// <summary>
    /// Репрезентация головного элемента вложения
    /// </summary>
    public sealed class AttachmentHeader
    {
        /// <summary>
        /// <para>
        /// Идентификатор вложения в строковом представлении UUID.
        /// Данный идентификатор используется в СМЭВ 3 для процессинга вложений.
        /// Идентификатор указывается только в том случае, если надо вручную указать
        /// идентификатор вложения при отправке в файловое хранилище.
        /// Для отправки вложения в файловое хранилище, необходимо указать режим передачи вложения <see cref="TransferMethodType.Reference"/>.
        /// </para>
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; } = default!;

        /// <summary>
        /// Путь к файлу
        /// </summary>
        [JsonProperty("filePath")]
        public string FilePath { get; set; } = default!;

        /// <summary>
        /// <para>Идентификатор паспорта вложения.</para>
        /// </summary>
        [JsonProperty("passportId")]
        public string? PassportId { get; set; }

        /// <summary>
        /// <para>ЭЦП в формате PKCS#7 detached. Подписывать ключом ЭП-СП.</para>
        /// </summary>
        [JsonProperty("SignaturePKCS7")]
        public byte[]? SignaturePkcs7 { get; set; }

        /// <summary>
        /// <para>
        /// Режим передачи вложения.
        /// Режим указывается только в том случае, если надо вручную указать режим передачи вложения.
        /// </para>
        /// </summary>
        [JsonProperty("TransferMethod")]
        public TransferMethodType TransferMethod { get; set; }

        /// <summary>
        /// <para>Переиспользуемое вложение.</para>
        /// </summary>
        [JsonProperty("ReusableAttachment")]
        public bool ReusableAttachment { get; set; }

        /// <summary>
        /// <para>Объявление передаваемых файлов в архиве.</para>
        /// </summary>
        [JsonProperty("File")]
        public List<FileType>? Archive {  get; set; }
    }
}
