using Newtonsoft.Json;

namespace SMEV.Adapter.Models.Send
{
    public sealed class ContentModel
    {
        public ContentModel(MessagePrimaryContentModel messagePrimaryContent) 
        {
            MessagePrimaryContent = messagePrimaryContent;
        }

        public ContentModel(MessagePrimaryContentModel messagePrimaryContent, AttachmentHeaderListModel? attachmentHeaderList) 
        {
            MessagePrimaryContent = messagePrimaryContent;
            AttachmentHeaderList = attachmentHeaderList;
        }

        [JsonProperty("messagePrimaryContent")]
        public MessagePrimaryContentModel MessagePrimaryContent { get; set; }
        [JsonProperty("attachmentHeaderList")]
        public AttachmentHeaderListModel? AttachmentHeaderList { get; set; }
    }
}
