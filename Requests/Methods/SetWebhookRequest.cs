using TeleBotDotNet.Http;
using TeleBotDotNet.Requests.Methods.Bases;

namespace TeleBotDotNet.Requests.Methods
{
    public class SetWebhookRequest : BaseMethodRequest
    {
        public string Url { get; set; }

        internal override string MethodName
        {
            get { return "setWebhook"; }
        }

        internal override HttpData Parse()
        {
            return new HttpData
            {
                Parameters = new HttpParameterList
                {
                    {"url", Url}
                }
            };
        }
    }
}