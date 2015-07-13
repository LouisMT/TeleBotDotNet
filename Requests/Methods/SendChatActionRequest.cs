using TeleBotDotNet.Http;
using TeleBotDotNet.Requests.Methods.Bases;
using TeleBotDotNet.Requests.Types;

namespace TeleBotDotNet.Requests.Methods
{
    public class SendChatActionRequest : BaseMethodRequest
    {
        public int ChatId { get; set; }
        public ActionRequest Action { get; set; }

        internal override string MethodName
        {
            get { return "sendChatAction"; }
        }

        internal override HttpData Parse()
        {
            var httpData = new HttpData
            {
                Parameters = new HttpParameterList
                {
                    {"chat_id", ChatId}
                }
            };

            if (Action != null)
            {
                Action.Parse(httpData, "action");
            }

            return httpData;
        }
    }
}