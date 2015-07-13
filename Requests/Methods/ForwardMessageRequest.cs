using TeleBotDotNet.Http;
using TeleBotDotNet.Requests.Methods.Bases;

namespace TeleBotDotNet.Requests.Methods
{
    public class ForwardMessageRequest : BaseMethodRequest
    {
        public int ChatId { get; set; }
        public int FromChatId { get; set; }
        public int MessageId { get; set; }

        internal override string MethodName
        {
            get { return "forwardMessage"; }
        }

        internal override HttpData Parse()
        {
            return new HttpData
            {
                Parameters = new HttpParameterList
                {
                    {"chat_id", ChatId},
                    {"from_chat_id", FromChatId},
                    {"message_id", MessageId}
                }
            };
        }
    }
}