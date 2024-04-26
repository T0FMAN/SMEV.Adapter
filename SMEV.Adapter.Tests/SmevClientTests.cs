namespace SMEV.Adapter.Tests
{
    public class SmevClientTests
    {
        const string baseAddress = "http://localhost:7590/ws";
        const string mnemonicIS = "000000";

        readonly ISmevClient _smevClient;

        public SmevClientTests() => _smevClient = new SmevClient(baseAddress, mnemonicIS);

        [Fact]
        public async void SendRequestMessageTest()
        {
            var text = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><ns0:ExportChargesRequest xmlns:com=\"http://roskazna.ru/gisgmp/xsd/Common/2.6.0\" xmlns:org=\"http://roskazna.ru/gisgmp/xsd/Organization/2.6.0\" xmlns:sc=\"http://roskazna.ru/gisgmp/xsd/SearchConditions/2.6.0\" xmlns:chg=\"http://roskazna.ru/gisgmp/xsd/Charge/2.6.0\" xmlns:ns0=\"urn://roskazna.ru/gisgmp/xsd/services/export-charges/2.6.0\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" Id=\"G_cfe0c895-b33d-33bc-28d8-697f21d9e561\" timestamp=\"2021-07-01T18:13:51.0\" senderIdentifier=\"3eacb7\" senderRole=\"1\"><com:Paging pageNumber=\"1\" pageLength=\"100\"/><sc:ChargesExportConditions kind=\"CHARGESTATUS\"><sc:ChargesConditions><sc:SupplierBillID>32117072411021588933</sc:SupplierBillID></sc:ChargesConditions></sc:ChargesExportConditions></ns0:ExportChargesRequest>";

            var clientId = Guid.NewGuid().ToString();

            var sentMessage = await _smevClient.SendRequestMessageAsync(
                mnemonicIS: mnemonicIS,
                clientId: clientId,
                messageContent: text,
                testMessage: true);

            Assert.NotNull(sentMessage);
            Assert.Equal(mnemonicIS, sentMessage.MnemonicIS);
            Assert.True(Guid.TryParse(sentMessage.MessageId, out var guid));
        }

        [Fact]
        public async void FindMessagesTest()
        {
            var query = await _smevClient.FindMessagesByTimeRangeAsync(
                mnemonicIS: mnemonicIS,
                fromDate: DateTime.Parse("2022-01-01T00:00:00+00:00"),
                toDate: DateTime.Parse("2025-01-10T00:00:00+00:00"),
                countToReturn: 10);

            Assert.NotNull(query);
            Assert.True(query.FoundMessages.Count == 10);
        }

        [Fact]
        public async void GetMessageTest()
        {
            try
            {
                while (true)
                {
                    var message = await _smevClient.GetMessageFromQueue(mnemonicIS);
                }
            }
            catch(Exception ex)
            {

            }
            //Assert.NotNull(message);
        }
    }
}