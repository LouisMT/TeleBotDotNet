using TeleBotDotNet.Responses.Methods.Bases;
using TeleBotDotNet.Responses.Types;

namespace TeleBotDotNet.Responses.Methods
{
    public class SendMessageResponse : BaseMethodResponse
    {
        public MessageResponse Result { get; set; }

        internal static SendMessageResponse Parse(dynamic data)
        {
            if (data == null)
            {
                return null;
            }

            return new SendMessageResponse
            {
                Ok = data.ok,
                ErrorCode = data.error_code,
                Description = data.description,
                Result = MessageResponse.Parse(data.result)
            };
        }
    }
}