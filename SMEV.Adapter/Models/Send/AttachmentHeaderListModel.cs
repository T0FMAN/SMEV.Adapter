using Newtonsoft.Json;

namespace SMEV.Adapter.Models.Send
{
    public sealed class AttachmentHeaderListModel
    {
        public AttachmentHeaderListModel(List<AttachmentHeaderModel> attachments) 
        {
            Attachments = attachments;
        }

        [JsonProperty("attachmentHeader")]
        public List<AttachmentHeaderModel> Attachments { get; set; }
    }
}
