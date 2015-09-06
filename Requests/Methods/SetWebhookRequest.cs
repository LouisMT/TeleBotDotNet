using TeleBotDotNet.Http;
using TeleBotDotNet.Requests.Methods.Bases;
using TeleBotDotNet.Requests.Types;

namespace TeleBotDotNet.Requests.Methods
{
    public class SetWebhookRequest : BaseMethodRequest
    {
        public string Url { get; set; }
        public InputFileRequest Certificate { get; set; }

        internal override string MethodName => "setWebhook";

        internal override HttpData Parse()
        {
            var httpData = new HttpData
            {
                Parameters = new HttpParameterList
                {
                    {"url", Url}
                }
            };

            Certificate?.Parse(httpData, "certificate");

            return httpData;
        }
    }
}