namespace SMEV.Adapter.Models.Find.ResponseFound
{
    public sealed class RequestMetadata
    {
        public string ClientId { get; set; }
        public LinkedGroupIdentity LinkedGroupIdentity { get; set; }
        public bool? TestMessage { get; set; }
        public string TransactionCode { get; set; }
    }
}
