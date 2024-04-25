namespace SMEV.Adapter.Tests
{
    public class SmevClientTests
    {
        static readonly string baseAddress = "http://localhost:7590/ws";
        static readonly string mnemonicIS = "000000";

        readonly ISmevClient _smevClient;

        public SmevClientTests() => _smevClient = new SmevClient(baseAddress, mnemonicIS);

        [Fact]
        public async void SendRequestTest()
        {
            var text = "<tns:MyRequest xmlns:tns='urn://test/1.0.1'>\r\n<tns:MyRequestString>test</tns:MyRequestString></tns:MyRequest>";

            var response = await _smevClient.SendRequestAsync(
                mnemonicIS: mnemonicIS,
                clientId: Guid.NewGuid().ToString(),
                messageContent: text,
                testMessage: true);

            Assert.NotNull(response);
            Assert.Equal(mnemonicIS, response.MnemonicIS);
            Assert.True(Guid.TryParse(response.MessageId, out var guid));
        }
    }
}