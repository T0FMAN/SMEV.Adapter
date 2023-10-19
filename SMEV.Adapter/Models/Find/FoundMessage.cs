using Newtonsoft.Json;
using SMEV.Adapter.Models.Find.ResponseFound;

namespace SMEV.Adapter.Models.Find
{
    /// <summary>
    /// Репрезентация найденного сообщения
    /// </summary>
    public sealed class FoundMessage
    {
        /// <summary>
        /// Метадата данных СМЭВ
        /// </summary>
        [JsonProperty("smevMetadata")]
        public SmevMetadata SmevMetadata { get; set; }
        /// <summary>
        /// Данные сообщения
        /// </summary>
        [JsonProperty("message")]
        public RequestMessage Message { get; set; }
    }
}
