using Newtonsoft.Json;

namespace SMEV.Adapter.Types.FindMethod
{
    public sealed class SmevMetadata
    {
        private DateTime _sendingDate;

        private readonly string mask = "yyyy-mm-dd'T'HH:mm:ss.ff'Z'";

        [JsonConstructor]
        public SmevMetadata(DateTime sendingDate)
        {
            _sendingDate = sendingDate;
        }

        [JsonProperty("messageId")]
        public string MessageId { get; set; }
        [JsonProperty("transactionCode")]
        public string TransactionCode { get; set; }
        [JsonProperty("originalMessageId")]
        public string OriginalMessageId { get; set; }
        [JsonProperty("sender")]
        public string Sender { get; set; }
        [JsonProperty("recipient")]
        public string Recipient { get; set; }
        [JsonProperty("sendingDate")]
        public string SendingDate
        {
            get
            {
                return _sendingDate.ToString(mask);
            }
        }
    }
}
