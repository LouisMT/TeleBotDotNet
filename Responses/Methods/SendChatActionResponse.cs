using TeleBotDotNet.Responses.Methods.Bases;

namespace TeleBotDotNet.Responses.Methods
{
    public class SendChatActionResponse : BaseMethodResponse
    {
        internal static SendChatActionResponse Parse(dynamic data)
        {
            if (data == null)
            {
                return null;
            }

            return new SendChatActionResponse
            {
                Ok = data.ok,
                ErrorCode = data.error_code,
                Description = data.description
            };
        }
    }
}