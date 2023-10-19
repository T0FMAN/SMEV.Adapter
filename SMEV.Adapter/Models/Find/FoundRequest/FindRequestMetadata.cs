namespace SMEV.Adapter.Models.Find.FoundRequest
{
    public sealed class FindRequestMetadata
    {
        public string ClientId { get; set; }
        public LinkedGroupIdentity LinkedGroupIdentity { get; set; }
        public bool? TestMessage { get; set; }
        public string TransactionCode { get; set; }
    }
}
