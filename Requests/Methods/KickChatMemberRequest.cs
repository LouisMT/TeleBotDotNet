using TeleBotDotNet.Http;
using TeleBotDotNet.Requests.Methods.Bases;

namespace TeleBotDotNet.Requests.Methods
{
    public class KickChatMemberRequest : BaseMethodRequest
    {
        public TeleChatId ChatId { get; set; }
        public int UserId { get; set; }

        internal override string MethodName => "kickChatMember";

        internal override HttpData Parse()
        {
            return new HttpData
            {
                Parameters = new HttpParameterList
                {
                    { "chat_id", ChatId },
                    { "user_id", UserId }
                }
            };
        }
    }
}
