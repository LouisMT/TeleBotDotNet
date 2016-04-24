using TeleBotDotNet.Json;
using TeleBotDotNet.Responses.Methods.Bases;

namespace TeleBotDotNet.Responses.Methods
{
    public class UnbanChatMemberResponse : BaseMethodResponse
    {
        public bool Result { get; private set; }

        internal static UnbanChatMemberResponse Parse(JsonData data)
        {
            if (data == null)
            {
                return null;
            }

            return new UnbanChatMemberResponse
            {
                Ok = data.Get<bool>("ok"),
                ErrorCode = data.Get<int?>("error_code"),
                Description = data.Get<string>("description"),
                Result = data.Get<bool>("result")
            };
        }
    }
}
