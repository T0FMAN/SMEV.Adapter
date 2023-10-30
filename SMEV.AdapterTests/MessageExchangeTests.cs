using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMEV.Adapter.Enums;
using SMEV.Adapter.Models.Find;
using SMEV.Adapter.Models.Send;
using SMEV.Adapter.Models.Send.Request;

namespace SMEV.Adapter.Tests
{
    [TestClass()]
    public class MessageExchangeTests
    {
        static readonly string baseAddress = "http://localhost:7590/ws";
        static readonly string mnemonicIS = "766201";

        readonly IMessageExchange _messageExchange = new MessageExchange(baseAddress, mnemonicIS);

        [TestMethod()]
        public async Task FindTest()
        {
            var clientId = "bf577137-513a-42a3-bf62-257cb0934424";

            var findRespByReqModel = new FindModel(clientId);

            var findResult = await _messageExchange.Find(findRespByReqModel);

            var findExcepted = findResult;

            Assert.AreEqual(findExcepted, findResult);
        }

        [TestMethod()]
        public async Task SendTest()
        {
            var clientId = Guid.NewGuid().ToString();

            var messageСommonTest = "<tns:MyRequest xmlns:tns='urn://test/1.0.1'>\r\n<tns:MyRequestString>test</tns:MyRequestString></tns:MyRequest>";
            var messageRPDD = "<tns:Request xmlns:tns='urn://mincomsvyaz/esia/receiving_personal_data_documents/1.0.1' xmlns:basic='urn://x-artefacts-smev-gov-ru/services/message-exchange/types/basic/1.3' xmlns:directive='urn://x-artefacts-smev-gov-ru/services/message-exchange/types/directive/1.3' xmlns:jxb='http://java.sun.com/xml/ns/jaxb' xmlns:xmime='http://www.w3.org/2005/05/xmlmime'>    <directive:Registry>        <directive:RegistryRecord>            <directive:RecordId>1</directive:RecordId>            <directive:Record>                <directive:RecordContent>                    <tns:ReceivingPersonalDataDocumentsRequest>                        <tns:dataType>inn</tns:dataType>                        <tns:personData>                            <tns:personV2>000-510-864 81</tns:personV2>                        </tns:personData>                    </tns:ReceivingPersonalDataDocumentsRequest>                </directive:RecordContent>            </directive:Record>        </directive:RegistryRecord>        <directive:RegistryRecord>            <directive:RecordId>2</directive:RecordId>            <directive:Record>                <directive:RecordContent>                    <tns:ReceivingPersonalDataDocumentsRequest>                        <tns:dataType>fullName</tns:dataType>                        <tns:personData>                            <tns:personV2>000-510-864 81</tns:personV2>                        </tns:personData>                    </tns:ReceivingPersonalDataDocumentsRequest>                </directive:RecordContent>            </directive:Record>        </directive:RegistryRecord>    </directive:Registry></tns:Request>";
            var messageEGRIP = "<?xml version='1.0' encoding='UTF-8'?><ns1:FNSVipipadrRequest xmlns:ns1='urn://x-artefacts-fns-vipipadr-ru/246-19/4.0.0' ИдДок='00000000-0000-0000-0000-000000000001' НомерДела='БН'><ns1:ЗапросИП><ns1:ОГРНИП>305500910900012</ns1:ОГРНИП></ns1:ЗапросИП></ns1:FNSVipipadrRequest>\r\n";
            
            var sendRequestModel = new SendRequestModel(clientId, messageRPDD, true);

            var actualSend = await _messageExchange.Send(sendRequestModel);
            var expectedSend = new ResponseSentMessage() { MnemonicIS = mnemonicIS, MessageId = clientId };

            Assert.AreEqual(expectedSend, actualSend);
        }
    }
}