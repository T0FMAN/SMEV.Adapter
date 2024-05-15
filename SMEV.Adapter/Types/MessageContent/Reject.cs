using Newtonsoft.Json;
using SMEV.Adapter.Types.Enums;

namespace SMEV.Adapter.Types.MessageContent
{
    /// <summary>
    /// 
    /// </summary>
    public class Reject
    {
        /// <summary>
        /// <para>Код причины отклонения запроса.</para>
        /// </summary>
        [JsonProperty("code")]
        public RejectCode Code { get; set; }

        /// <summary>
        /// <para>Описание причины отклонения запроса.</para>
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; } = default!;
    }
}
