using TeleBotDotNet.Http;
using TeleBotDotNet.Requests.Methods.Bases;
using TeleBotDotNet.Requests.Types;

namespace TeleBotDotNet.Requests.Methods
{
    public class SetWebhookRequest : BaseMethodRequest
    {
        public string Url { get; set; }
        public InputFileRequest Certificate { get; set; }

        internal override string MethodName
        {
            get { return "setWebhook"; }
        }

        internal override HttpData Parse()
        {
            var httpData = new HttpData
            {
                Parameters = new HttpParameterList
                {
                    {"url", Url}
                }
            };

            if (Certificate != null)
            {
                Certificate.Parse(httpData, "certificate");
            }

            return httpData;
        }
    }
}