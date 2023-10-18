using Newtonsoft.Json;

namespace SMEV.Adapter.Models.Find.ResponseFound
{
    public sealed class SmevMetadata
    {
        private DateTime _sendingDate;

        private readonly string mask = "yyyy-mm-dd'T'HH:mm:ss.ff'Z'";

        [JsonConstructor]
        public SmevMetadata(DateTime sendingDate, string messageId, string transactionCode, string sender)
        {
            _sendingDate = sendingDate;
            MessageId = messageId;
            TransactionCode = transactionCode;
            Sender = sender;
        }

        [JsonProperty("messageId")]
        public string MessageId { get; set; }
        [JsonProperty("transactionCode")]
        public string TransactionCode { get; set; }
        [JsonProperty("sender")]
        public string Sender { get; set; }
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
