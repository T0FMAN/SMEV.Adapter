using Newtonsoft.Json;

namespace SMEV.Adapter.Models.Send
{
    public sealed class AttachmentHeaderModel
    {
        public AttachmentHeaderModel(string filePath)
        {
            FilePath = filePath;
        }

        [JsonProperty("filePath")]
        public string FilePath { get; set; }
    }
}
